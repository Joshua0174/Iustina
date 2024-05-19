using BusinessLayer.Contracts;
using BusinessLayer.Dto.Book;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using BusinessLayer.Mappers;
namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet("getAllBooks")]
        public IActionResult GetAll()
        {
            var books = _bookService.GetAll();
            if (books.IsNullOrEmpty())
            {
                return NotFound("There are no books in the library");
            }
            return Ok(books);
        }

        [HttpGet("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var book = _bookService.GetById(id);
            if (book == null)
            {
                return NotFound("This book doesn't exist");
            }
            return Ok(book);
        }

        [HttpPut("Update")]
       
        public IActionResult Update(Guid id, [FromBody] UpdateBookDto updateBookDto)
        {
            var bookModel = _bookService.GetById(id);
            if (bookModel == null)
            {
                return NotFound("Cannot find this book");
            }
            var updatedBook = _bookService.Update(id, updateBookDto.ToBookFromUpdateDto());
            if (updatedBook == null)
            {
                return BadRequest("Something went wrong!");
            }
            return Ok("This book was updated as succesfully!");
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] CreateBookDto createBookDto)
        {
            var bookModel = _bookService.Create(createBookDto.ToBookFromCreateDto());
            if (bookModel == null)
            {
                return BadRequest("Something went wrong!");
            }
            return Ok(bookModel);
        }

        [HttpDelete("Delete Product")]
        
        public IActionResult Delete(Guid id)
        {
            var deletedBook= _bookService.Delete(id);
            if(deletedBook == null)
            {
                return BadRequest("Sorry! Cannot delete this book!");
            }
            return Ok(deletedBook); 
        }
    }
}
