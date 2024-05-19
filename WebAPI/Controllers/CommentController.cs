using BusinessLayer.Contracts;
using BusinessLayer.Dto.Comment;
using BusinessLayer.Dto.CommentDtO;
using BusinessLayer.Mappers;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;
using static BusinessLayer.Services.CommentService;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController : ControllerBase
    {
         
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }


        [HttpPost("CreateComment")]   
        public IActionResult Create(Guid id,CreateCommentDto createCommentDto)
        {
            
            var comment=createCommentDto.ToCommentFromCreateDto(id);
            var comment1= _commentService.Create(comment);
            if (comment1==null)
            {
                return BadRequest("Something went wrong!");
            }
            return Ok("Comment was created");

        }
        
        [HttpDelete("DeleteComment")]
         
        public IActionResult Delete(Guid id)
        {
            var callback = _commentService.Delete;
            var comment = _commentService.DeleteDelegate(id,callback);
            if (comment == null)
            {
                return BadRequest("Comment not found");
            }
            return Ok("Comment was deleted as succesfully!");
        }
    }
}
