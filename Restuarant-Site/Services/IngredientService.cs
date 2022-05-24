using Restuarant_Site.Data.Repositories;
using Restuarant_Site.Models;

namespace Restuarant_Site.Services
{
    public class IngredientService : ICrudService<Ingredient, int>
    {
        private readonly ICrudRepository<Ingredient, int> _ingredientRepository;
        public IngredientService(ICrudRepository<Ingredient, int> todoRepository)
        {
            _ingredientRepository = todoRepository;
        }
        public void Add(Ingredient element)
        {
            _ingredientRepository.Add(element);
            _ingredientRepository.Save();
        }
        public void Delete(int id)
        {
            _ingredientRepository.Delete(id);
            _ingredientRepository.Save();
        }
        public Ingredient Get(int id)
        {
            return _ingredientRepository.Get(id);
        }
        public IEnumerable<Ingredient> GetAll()
        {
            return _ingredientRepository.GetAll();
        }
        public void Update(Ingredient old, Ingredient newT)
        {
            old.Item = newT.Item;
            old.Type = newT.Type;
            old.Calories = newT.Calories;
            old.Price = newT.Price;
            old.Status = newT.Status;
            _ingredientRepository.Update(old);
            _ingredientRepository.Save();
        }
    }
}
