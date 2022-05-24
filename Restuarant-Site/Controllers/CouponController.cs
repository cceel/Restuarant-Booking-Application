using Microsoft.AspNetCore.Mvc;
using Restuarant_Site.Models;
using Restuarant_Site.Services;

namespace Restuarant_Site.Controllers
{
    [ApiController]
    [Route("[controller]")]//URL: http://localhost:5066/coupon
    public class CouponController : ControllerBase
    {
        private readonly ICrudService<Coupon, int> _couponService;
        public CouponController(ICrudService<Coupon, int> couponService)
        {
            _couponService = couponService;
        }

        // GET all action
        [HttpGet] // auto returns data with a Content-Type of application/json
        public ActionResult<List<Coupon>> GetAll() => _couponService.GetAll().ToList();

        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<Coupon> Get(int id)
        {
            var todo = _couponService.Get(id);
            if (todo is null) return NotFound();
            else return todo;
        }

        // POST action
        [HttpPost]
        public IActionResult Create(Coupon todo)
        {
            // Runs validation against model using data validation attributes
            if (ModelState.IsValid)
            {
                _couponService.Add(todo);
                return CreatedAtAction(nameof(Create), new { id = todo.Id }, todo);
            }
            return BadRequest();
        }

        // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(int id, Coupon todo)
        {
            var existingTodoItem = _couponService.Get(id);
            if (existingTodoItem is null || existingTodoItem.Id != id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                _couponService.Update(existingTodoItem, todo);
                return NoContent();
            }
            return BadRequest();
        }

        // DELETE action
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var todo = _couponService.Get(id);
            if (todo is null) return NotFound();
            _couponService.Delete(id);
            return NoContent();
        }
    }
}
