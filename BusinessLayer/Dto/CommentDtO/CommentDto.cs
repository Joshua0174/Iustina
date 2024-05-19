using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Dto.Comment
{
    public class CommentDto
    {   
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public int Rating { get; set; }
        public Guid BookId { get; set; }= Guid.Empty;
        //public DataAccessLayer.Models.Book Book { get; set; }
    }
}
