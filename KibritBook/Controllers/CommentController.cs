using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CosmetsyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentManager _commentManager;

        public CommentController(ICommentManager commentManager)
        {
            _commentManager = commentManager;
        }

        [HttpGet("getallbyid")]
        public IActionResult GetAllById(int productId)
        {
            var comments = _commentManager.GetCommentById(productId);
            if (comments == null)
                return Ok(new { status = 404, message = "Comment yoxdur." });
            return Ok(new { status = 200, message = comments });
        }

        [HttpGet("getallbyuserid")]
        public IActionResult GetAllByUserId(string userEmail)
        {
            var comments = _commentManager.GetCommentByUserId(userEmail);
            if (comments == null)
                return Ok(new { status = 404, message = "Comment yoxdur." });
            return Ok(new { status = 200, message = comments });
        }

        [HttpPost("addcomment")]
        public IActionResult AddComment(CommentDTO comment)
        {
            try
            {
                _commentManager.AddComment(comment);
                return Ok(new { status = 200, message = "Comment elave olundu." });
            }
            catch (Exception)
            {
                return Ok(new { status = 400, message = "Comment yazarken xeta bas verdi." });
            }
        }

        [HttpGet("allcomments")]
        public async Task<IActionResult> GetAllComment()
        {
            var comment = _commentManager.GetAllComment();
            return Ok(new { status = 200, message = comment });
        }

        [HttpDelete("remove/{id}")]
        public async Task<IActionResult> DeleteComment(CommentDTO model, int id)
        {
            _commentManager.Remove(model, id);
            return Ok("Melumat ugurla silindi.");
        }
    }
}
