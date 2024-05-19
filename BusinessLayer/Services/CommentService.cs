using BusinessLayer.Contracts;
using BusinessLayer.Dto.Comment;
using BusinessLayer.Mappers;
using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class CommentService : ICommentService
    {   
        private readonly IRepository<Comment> _commentRepository;
        public CommentService(IRepository<Comment> commentRepository)
        {
            _commentRepository = commentRepository;
        }
        public CommentDto Create(Comment commentModel)
        {
            _commentRepository.Add(commentModel);
            _commentRepository.SaveChanges();
            return commentModel.ToCommentDto();
        }

        public CommentDto Delete(Guid id)
        {
            var comment = _commentRepository.Find(c => c.Id == id).FirstOrDefault();
            if (comment == null)
            {
                return null;
            }
            _commentRepository.Remove(comment);
            _commentRepository.SaveChanges();
            return comment.ToCommentDto();
        }

        public CommentDto DeleteDelegate(Guid id,Func<Guid,CommentDto> callback)
        {
            return callback(id);
        }
    }
}
