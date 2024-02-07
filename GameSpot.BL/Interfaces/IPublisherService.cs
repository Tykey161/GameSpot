using GameSpot.Models;

namespace GameSpot.BL.Interfaces
{
    public interface IPublisherService
    {
        Publisher GetById(int id);
        IEnumerable<Publisher> GetAll();
        void Add(Publisher publisher);
        void Update(Publisher publisher);
        void Delete(int id);
    }
}
