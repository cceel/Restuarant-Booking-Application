using Microsoft.AspNetCore.Mvc;
using Restuarant_Site.Models;
using Restuarant_Site.Services;

namespace Restuarant_Site.Controllers
{
    [ApiController]
    [Route("[controller]")]//URL: http://localhost:5066/ingredient
    public class IngredientController : ControllerBase
    {
        private readonly ICrudService<Ingredient, int> _ingredientService;
        public IngredientController(ICrudService<Ingredient, int> ingredientService)
        {
            _ingredientService = ingredientService;
        }

        // GET all action
        [HttpGet] // auto returns data with a Content-Type of application/json
        public ActionResult<List<Ingredient>> GetAll() => _ingredientService.GetAll().ToList();

        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<Ingredient> Get(int id)
        {
            var todo = _ingredientService.Get(id);
            if (todo is null) return NotFound();
            else return todo;
        }

        // POST action
        [HttpPost]
        public IActionResult Create(Ingredient todo)
        {
            // Runs validation against model using data validation attributes
            if (ModelState.IsValid)
            {
                _ingredientService.Add(todo);
                return CreatedAtAction(nameof(Create), new { id = todo.Id }, todo);
            }
            return BadRequest();
        }

        // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(int id, Ingredient todo)
        {
            var existingTodoItem = _ingredientService.Get(id);
            if (existingTodoItem is null || existingTodoItem.Id != id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                _ingredientService.Update(existingTodoItem, todo);
                return NoContent();
            }
            return BadRequest();
        }

        // DELETE action
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var todo = _ingredientService.Get(id);
            if (todo is null) return NotFound();
            _ingredientService.Delete(id);
            return NoContent();
        }
    }
}