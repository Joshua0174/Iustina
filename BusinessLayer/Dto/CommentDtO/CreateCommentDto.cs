using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Dto.CommentDtO
{
    public class CreateCommentDto
    {
       
        public string UserName { get; set; }
        public string Content { get; set; } = string.Empty;
        public int Rating { get; set; }
        
    }
}
