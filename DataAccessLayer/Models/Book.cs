using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Book:BaseEntity
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }

        public byte[]? BookPicture { get; set; }

        public void UpdateBookPicture(byte[] bookPicture)
        {
            BookPicture = bookPicture;
        }

        public List<Comment> Comments { get; set; } = new List<Comment>(); //comentarii
       
       
    }
}
