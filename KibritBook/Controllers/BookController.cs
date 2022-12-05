using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KibritBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookManager _bookManager;
        private readonly IWebHostEnvironment _environment;

        public BookController(IBookManager bookManager, IWebHostEnvironment environment)
        {
            _bookManager = bookManager;
            _environment = environment;
        }

        [HttpGet("bookList")]
        public IActionResult BookList()
        {
            var productList = _bookManager.GetAllBookList();
            return Ok(new { status = 200, message = productList });
        }

        [HttpGet("getbyid/{id}")]
        public IActionResult GetById(int id)
        {
            var product = _bookManager.GetBookById(id);
            return Ok(new { status = 200, message = product });
        }

        [HttpPost("add")]
        public IActionResult AddProduct(AddBookDTO product)
        {
            try
            {
                _bookManager.AddBook(product);
            }
            catch (Exception e)
            {
                return Ok(new { status = 400, message = e });
            }

            return Ok(new { status = 200, message = "Mehsul elave olundu." });
        }

        [HttpPost("uploadcover")]
        public async Task<IActionResult> UploadPhotoAsync(IFormFile Image)
        {
            string path = "/files/" + Guid.NewGuid() + Image.FileName;
            using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
            {
                await Image.CopyToAsync(fileStream);
            }
            return Ok(new { status = 200, message = path });
        }


        [HttpPost("uploadimages")]
        public async Task<IActionResult> UploadImagesAsync(IFormFile Image)
        {
            string path = "/files/" + Guid.NewGuid() + Image.FileName;
            using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
            {
                await Image.CopyToAsync(fileStream);
            }

            List<string> photos = new();

            return Ok(new { status = 200, message = path });
        }

        [HttpPut("updatebook/{id}")]
        public async Task<IActionResult> UpdateProduct(AddBookDTO model, int id)
        {

            _bookManager.UpdateBook(model, id);
            return Ok(new { status = 200, message = "Mehsul yenilendi" });
        }

        [HttpDelete("removebook/{id}")]
        public async Task<IActionResult> RemoveProduct(AddBookDTO model, int id)
        {

            _bookManager.RemoveBook(model, id);
            return Ok(new { status = 200, message = "Mehsul silindi" });
        }
    }
}
