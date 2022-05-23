using Microsoft.AspNetCore.Mvc;
using Restuarant_Site.Models;
using Restuarant_Site.Services;

namespace Restuarant_Site.Controllers
{
    [ApiController]
    [Route("[controller]")]//URL: http://localhost:5066/booking
    public class BookingController : ControllerBase
    {
        private readonly ICrudService<Booking, int> _bookingService;
        public BookingController(ICrudService<Booking, int> bookingService)
        {
            _bookingService = bookingService;
        }

        // GET all action
        [HttpGet] // auto returns data with a Content-Type of application/json
        public ActionResult<List<Booking>> GetAll() => _bookingService.GetAll().ToList();

        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<Booking> Get(int id)
        {
            var todo = _bookingService.Get(id);
            if (todo is null) return NotFound();
            else return todo;
        }

        // POST action
        [HttpPost]
        public IActionResult Create(Booking todo)
        {
            // Runs validation against model using data validation attributes
            if (ModelState.IsValid)
            {
                _bookingService.Add(todo);
                return CreatedAtAction(nameof(Create), new { id = todo.Id }, todo);
            }
            return BadRequest();
        }

        // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(int id, Booking todo)
        {
            var existingTodoItem = _bookingService.Get(id);
            if (existingTodoItem is null || existingTodoItem.Id != id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                _bookingService.Update(existingTodoItem, todo);
                return NoContent();
            }
            return BadRequest();
        }

        // DELETE action
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var todo = _bookingService.Get(id);
            if (todo is null) return NotFound();
            _bookingService.Delete(id);
            return NoContent();
        }
    }
}
