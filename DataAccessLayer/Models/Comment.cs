using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Comment
    {    
        public Guid Id { get; set; }
        public string UserName {  get; set; }
        public string Content {  get; set; }=string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public int Rating { get; set; }

        public Guid BookId {  get; set; }
        public Book Book { get; set; }
    }
}
