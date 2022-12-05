using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KibritBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly ILanguageManager _languageManager;

        public LanguageController(ILanguageManager languageManager)
        {
            _languageManager = languageManager;
        }

        [HttpGet("getall")]
        public List<Language> GetAll()
        {
            return _languageManager.GetAllLanguage();
        }

        [HttpGet("getbyid/{id}")]
        public IActionResult GetById(int id)
        {
            var genre = _languageManager.GetLanguageById(id);
            return Ok(new { status = 200, message = genre });
        }


        [HttpPost("add")]
        public object AddLanguage(Language language)
        {
            _languageManager.Add(language);
            return Ok("Language added");
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateLanguage(Language language, int id)
        {
            _languageManager.Update(language, id);
            return Ok(new { status = 200, message = "Mehsul yenilendi." });
        }

        [HttpDelete("remove/{id}")]
        public async Task<IActionResult> DeleteLanguage(Language language, int id)
        {
            _languageManager.Remove(language, id);
            return Ok("Melumat ugurla silindi.");
        }
    }
}
