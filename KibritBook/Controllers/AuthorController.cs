using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KibritBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorManager _authorManager;

        public AuthorController(IAuthorManager authorManager)
        {
            _authorManager = authorManager;
        }

        [HttpGet("getall")]
        public List<Author> GetAll()
        {
            return _authorManager.GetAllAuthor();
        }

        [HttpGet("getbyid/{id}")]
        public IActionResult GetById(int id)
        {
            var author = _authorManager.GetAuthorById(id);
            return Ok(new { status = 200, message = author });
        }


        [HttpPost("add")]
        public object AddAuthor(Author author)
        {
            _authorManager.Add(author);
            return Ok("Author added");
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateAuthor(Author author, int id)
        {
            _authorManager.Update(author, id);
            return Ok(new { status = 200, message = "Mehsul yenilendi." });
        }

        [HttpDelete("remove/{id}")]
        public async Task<IActionResult> DeleteAuthor(Author author, int id)
        {
            _authorManager.Remove(author, id);
            return Ok("Melumat ugurla silindi.");
        }
    }
}
