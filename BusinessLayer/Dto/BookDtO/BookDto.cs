using BusinessLayer.Dto.Comment;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Dto.Book
{
    public class BookDto
    {   
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public string Picture { get; set; }
        public List<CommentDto> Comments { get; set; } 
    }
}
