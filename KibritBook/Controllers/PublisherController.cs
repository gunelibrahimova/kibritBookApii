using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KibritBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherManager _publisherManager;

        public PublisherController(IPublisherManager publisherManager)
        {
            _publisherManager = publisherManager;
        }

        [HttpGet("getall")]
        public List<Publisher> GetAll()
        {
            return _publisherManager.GetAllPublisher();
        }

        [HttpGet("getbyid/{id}")]
        public IActionResult GetById(int id)
        {
            var genre = _publisherManager.GetPublisherById(id);
            return Ok(new { status = 200, message = genre });
        }


        [HttpPost("add")]
        public object AddPublisher(Publisher publisher)
        {
            _publisherManager.Add(publisher);
            return Ok("Publisher added");
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdatePublisher(Publisher publisher, int id)
        {
            _publisherManager.Update(publisher, id);
            return Ok(new { status = 200, message = "Mehsul yenilendi." });
        }

        [HttpDelete("remove/{id}")]
        public async Task<IActionResult> DeletePublisher(Publisher publisher, int id)
        {
            _publisherManager.Remove(publisher, id);
            return Ok("Melumat ugurla silindi.");
        }
}
}
