using Restuarant_Site.Data.Repositories;
using Restuarant_Site.Models;

namespace Restuarant_Site.Services
{
    public class BookingService : ICrudService<Booking, int>
    {
        private readonly ICrudRepository<Booking, int> _todoRepository;
        public BookingService(ICrudRepository<Booking, int> todoRepository)
        {
            _todoRepository = todoRepository;
        }
        public void Add(Booking element)
        {
            _todoRepository.Add(element);
            _todoRepository.Save();
        }
        public void Delete(int id)
        {
            _todoRepository.Delete(id);
            _todoRepository.Save();
        }
        public Booking Get(int id)
        {
            return _todoRepository.Get(id);
        }
        public IEnumerable<Booking> GetAll()
        {
            return _todoRepository.GetAll();
        }
        public void Update(Booking old, Booking newT)
        {
            old.Location = newT.Location;
            old.BookingDateTime = newT.BookingDateTime;
            old.FirstName = newT.FirstName;
            old.LastName = newT.LastName;
            old.PhoneNumber = newT.PhoneNumber;
            old.PartySize = newT.PartySize;
            old.Notes = newT.Notes;
            old.Info = newT.Info;
            old.Status = newT.Status;
            _todoRepository.Update(old);
            _todoRepository.Save();
        }
    }
}
