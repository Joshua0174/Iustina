using BusinessLayer.Dto.Comment;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Contracts
{
    public interface ICommentService
    {
        CommentDto Create(Comment commentModel);
        CommentDto Delete(Guid id);

        CommentDto DeleteDelegate(Guid id,Func<Guid,CommentDto> callBack);
       
    }
}
