using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KibritBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreManager _genreManager;

        public GenreController(IGenreManager genreManager)
        {
            _genreManager = genreManager;
        }

        [HttpGet("getall")]
        public List<Genre> GetAll()
        {
            return _genreManager.GetAllGenres();
        }

        [HttpGet("getbyid/{id}")]
        public IActionResult GetById(int id)
        {
            var genre = _genreManager.GetGenreById(id);
            return Ok(new { status = 200, message = genre });
        }


        [HttpPost("add")]
        public object AddGenre(Genre genre)
        {
            _genreManager.Add(genre);
            return Ok("Genre added");
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateGenre(Genre genre, int id)
        {
            _genreManager.Update(genre, id);
            return Ok(new { status = 200, message = "Mehsul yenilendi." });
        }

        [HttpDelete("remove/{id}")]
        public async Task<IActionResult> DeleteGenre(Genre genre, int id)
        {
            _genreManager.Remove(genre, id);
            return Ok("Melumat ugurla silindi.");
        }
    }
}
