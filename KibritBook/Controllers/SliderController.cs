using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KibritBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderManager _sliderManager;

        public SliderController(ISliderManager sliderManager)
        {
            _sliderManager = sliderManager;
        }

        [HttpGet("getall")]
        public List<Slider> GetAll()
        {
            return _sliderManager.GetAllSliders();
        }

        [HttpGet("getbyid/{id}")]
        public IActionResult GetById(int id)
        {
            var slider = _sliderManager.GetSliderById(id);
            return Ok(new { status = 200, message = slider });;
        }


        [HttpPost("add")]
        public object AddSlider(Slider slider)
        {
            _sliderManager.Add(slider);
            return Ok("Slider added");
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateSlider(Slider slider, int id)
        {
            _sliderManager.Update(slider, id);
            return Ok(new { status = 200, message = "Mehsul yenilendi." });
        }

        [HttpDelete("remove/{id}")]
        public async Task<IActionResult> DeleteSlider(Slider slider, int id)
        {
            _sliderManager.Remove(slider, id);
            return Ok("Melumat ugurla silindi.");
        }
    }
}
