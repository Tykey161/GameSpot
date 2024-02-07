using Microsoft.AspNetCore.Mvc;
using GameSpot.BL.Interfaces;
using GameSpot.Models;

namespace GameSpot.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherService _publisherService;

        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService ?? throw new ArgumentNullException(nameof(publisherService));
        }

        [HttpGet]
        public IEnumerable<Publisher> GetAllPublishers()
        {
            return _publisherService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Publisher> GetPublisher(int id)
        {
            var publisher = _publisherService.GetById(id);
            if (publisher == null)
            {
                return NotFound();
            }
            return publisher;
        }

        [HttpPost]
        public IActionResult AddPublisher(Publisher publisher)
        {
            if (publisher == null)
            {
                return BadRequest();
            }

            _publisherService.Add(publisher);

            return CreatedAtAction(nameof(GetPublisher), new { id = publisher.Id }, publisher);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePublisher(int id, Publisher publisher)
        {
            if (id != publisher.Id)
            {
                return BadRequest();
            }

            try
            {
                _publisherService.Update(publisher);
            }
            catch (Exception)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePublisher(int id)
        {
            var publisher = _publisherService.GetById(id);
            if (publisher == null)
            {
                return NotFound();
            }

            _publisherService.Delete(id);

            return NoContent();
        }
    }
}
