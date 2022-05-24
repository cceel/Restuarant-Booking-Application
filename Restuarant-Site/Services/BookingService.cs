using Restuarant_Site.Data.Repositories;
using Restuarant_Site.Models;

namespace Restuarant_Site.Services
{
    public class BookingService : ICrudService<Booking, int>
    {
        private readonly ICrudRepository<Booking, int> _bookingRepository;
        public BookingService(ICrudRepository<Booking, int> todoRepository)
        {
            _bookingRepository = todoRepository;
        }
        public void Add(Booking element)
        {
            _bookingRepository.Add(element);
            _bookingRepository.Save();
        }
        public void Delete(int id)
        {
            _bookingRepository.Delete(id);
            _bookingRepository.Save();
        }
        public Booking Get(int id)
        {
            return _bookingRepository.Get(id);
        }
        public IEnumerable<Booking> GetAll()
        {
            return _bookingRepository.GetAll();
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
            _bookingRepository.Update(old);
            _bookingRepository.Save();
        }
    }
}
