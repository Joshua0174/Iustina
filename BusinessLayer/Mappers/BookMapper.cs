using BusinessLayer.Converter;
using BusinessLayer.Dto.Book;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Mappers
{
    public static class BookMapper
    {

        public static BookDto ToBookDto(this Book bookModel)
        {
            return new BookDto
            {
                Id = bookModel.Id,
                Title = bookModel.Title,
                Description = bookModel.Description,
                Author = bookModel.Author,
                Genre = bookModel.Genre,
                //Picture = ImageConverter.ImageToBase64(bookModel.BookPicture),
                Comments = bookModel.Comments.Select(c => c.ToCommentDto()).ToList()
            };
        }

        public static Book ToBookFromCreateDto(this CreateBookDto createBookDto)
        {
            return new Book
            {
               
                Title = createBookDto.Title,
                Description = createBookDto.Description,
                Author = createBookDto.Author,
                Genre = createBookDto.Genre,

               // BookPicture = ImageConverter.Base64ToImage(createBookDto.Picture),
            };
        }
        public static Book ToBookFromUpdateDto(this UpdateBookDto createBookDto)
        {
            return new Book
            {

                Title = createBookDto.Title,
                Description = createBookDto.Description,
                Author = createBookDto.Author,
                Genre = createBookDto.Genre,
              //  BookPicture = ImageConverter.Base64ToImage(createBookDto.Picture),
            };
        }
    }
}
