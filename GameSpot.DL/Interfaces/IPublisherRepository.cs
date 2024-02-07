using GameSpot.Models;

namespace GameSpot.DL.Interfaces
{
    public interface IPublisherRepository
    {
        Publisher GetById(int id);
        IEnumerable<Publisher> GetAll();
        void Add(Publisher publisher);
        void Update(Publisher publisher);
        void Delete(int id);
    }
}
