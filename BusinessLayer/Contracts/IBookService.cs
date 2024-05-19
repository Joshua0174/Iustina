using BusinessLayer.Dto.Book;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Contracts
{
    public interface IBookService
    {
        List<BookDto> GetAll();
        BookDto GetById(Guid id);
        BookDto Delete(Guid id);

        BookDto Create(Book bookModel);

        BookDto Update(Guid id, Book bookModel);


    }
    
}
