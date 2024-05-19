using BusinessLayer.Contracts;
using BusinessLayer.Dto.Book;
using BusinessLayer.Dto.Comment;
using BusinessLayer.Mappers;
using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{

    public class BookService : IBookService
    {
        private readonly IRepository<Book> _repository;
        public BookService(IRepository<Book> repository)
        {
            _repository = repository;
        }
        public BookDto Create(Book bookModel)
        {
            _repository.Add(bookModel);
            _repository.SaveChanges();
            return bookModel.ToBookDto();
        }

        public BookDto Delete(Guid id)
        {
            var book = _repository.Find(c=>c.Id==id).FirstOrDefault();
            if (book == null)
            {
                return null;
            }
            _repository.Remove(book);
            _repository.SaveChanges();
            return book.ToBookDto();
        }

        public List<BookDto> GetAll()
        {
            var booksWithComments = _repository.GetAllAsQuery().Include(c => c.Comments).ToList();

            return booksWithComments.Select(c => c.ToBookDto()).ToList();
        }

        public BookDto GetById(Guid id)
        {
            var bookWithComments = (from book in _repository.GetAllAsQuery()
                                    where book.Id == id
                                    select new
                                    {
                                        Book = book,
                                        Comments = book.Comments.ToList()
                                    }).FirstOrDefault();

            if (bookWithComments == null) { return null; };

            var bookDto = bookWithComments.Book.ToBookDto();

            bookDto.Comments = bookWithComments.Comments.Select(c => c.ToCommentDto()).ToList();

            return bookDto;

        }

        public BookDto Update(Guid id, Book bookModel)
        {
            var book = _repository.Find(c=>c.Id==id).FirstOrDefault();
            if(book == null)
            {
                return null;
            }
            book.Author= bookModel.Author;
            book.Title= bookModel.Title;
            book.Description = bookModel.Description;
            book.Description=bookModel.Description;
            book.BookPicture= bookModel.BookPicture;
            book.Genre= bookModel.Genre;
            _repository.Update(book);
            _repository.SaveChanges();
           
            return book.ToBookDto();
        }
    }
}
