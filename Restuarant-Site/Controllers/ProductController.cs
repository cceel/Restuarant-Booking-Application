using Microsoft.AspNetCore.Mvc;
using Restuarant_Site.Models;
using Restuarant_Site.Services;

namespace Restuarant_Site.Controllers
{
    [ApiController]
    [Route("[controller]")]//URL: http://localhost:5066/product
    public class ProductController : ControllerBase
    {
        private readonly ICrudService<Product, int> _productService;
        public ProductController(ICrudService<Product, int> productService)
        {
            _productService = productService;
        }

        // GET all action
        [HttpGet] // auto returns data with a Content-Type of application/json
        public ActionResult<List<Product>> GetAll() => _productService.GetAll().ToList();

        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var todo = _productService.Get(id);
            if (todo is null) return NotFound();
            else return todo;
        }

        // POST action
        [HttpPost]
        public IActionResult Create(Product todo)
        {
            // Runs validation against model using data validation attributes
            if (ModelState.IsValid)
            {
                _productService.Add(todo);
                return CreatedAtAction(nameof(Create), new { id = todo.Id }, todo);
            }
            return BadRequest();
        }

        // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(int id, Product todo)
        {
            var existingTodoItem = _productService.Get(id);
            if (existingTodoItem is null || existingTodoItem.Id != id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                _productService.Update(existingTodoItem, todo);
                return NoContent();
            }
            return BadRequest();
        }

        // DELETE action
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var todo = _productService.Get(id);
            if (todo is null) return NotFound();
            _productService.Delete(id);
            return NoContent();
        }
    }
}
