using BusinessLayer.Dto.Comment;
using BusinessLayer.Dto.CommentDtO;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Mappers
{
    public static class CommentMapper
    {
        public static CommentDto ToCommentDto(this Comment commentModel)
        {
            return new CommentDto
            {
                Id = commentModel.Id,
                UserName = commentModel.UserName,
                Content = commentModel.Content,
                CreatedOn = commentModel.CreatedOn,
                Rating = commentModel.Rating,
                BookId = commentModel.BookId,
            };
        }

        public static Comment ToCommentFromCreateDto(this CreateCommentDto commentDto, Guid bookId)
        {
            return new Comment
            {
                
                UserName = commentDto.UserName,
                Content = commentDto.Content,
                //CreatedOn = commentDto.CreatedOn,
                Rating = commentDto.Rating,
                BookId = bookId,
            };
        }

    }
}
