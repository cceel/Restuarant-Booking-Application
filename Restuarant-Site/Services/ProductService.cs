using Restuarant_Site.Data.Repositories;
using Restuarant_Site.Models;

namespace Restuarant_Site.Services
{
    public class ProductService : ICrudService<Product, int>
    {
        private readonly ICrudRepository<Product, int> _productRepository;
        public ProductService(ICrudRepository<Product, int> todoRepository)
        {
            _productRepository = todoRepository;
        }
        public void Add(Product element)
        {
            _productRepository.Add(element);
            _productRepository.Save();
        }
        public void Delete(int id)
        {
            _productRepository.Delete(id);
            _productRepository.Save();
        }
        public Product Get(int id)
        {
            return _productRepository.Get(id);
        }
        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }
        public void Update(Product old, Product newT)
        {
            old.Item = newT.Item;
            old.Type = newT.Type;
            old.Calories = newT.Calories;
            old.Price = newT.Price;
            old.Status = newT.Status;
            _productRepository.Update(old);
            _productRepository.Save();
        }
    }
}
