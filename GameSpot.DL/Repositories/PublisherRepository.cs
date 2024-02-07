using GameSpot.DL.Interfaces;
using GameSpot.DL.MemoryDb;
using GameSpot.Models;

namespace GameSpot.DL.Repositories
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly List<Publisher> _publishers;

        public PublisherRepository()
        {
            _publishers = InMemoryDb.PublisherData;
        }

        public void Add(Publisher publisher)
        {
            if (publisher == null)
                throw new ArgumentNullException(nameof(publisher));

            _publishers.Add(publisher);
        }

        public void Delete(int id)
        {
            var publisherToRemove = _publishers.FirstOrDefault(p => p.Id == id);
            if (publisherToRemove != null)
                _publishers.Remove(publisherToRemove);
        }

        public IEnumerable<Publisher> GetAll()
        {
            return _publishers.ToList();
        }

        public Publisher GetById(int id)
        {
            return _publishers.FirstOrDefault(p => p.Id == id);
        }

        public void Update(Publisher publisher)
        {
            if (publisher == null)
                throw new ArgumentNullException(nameof(publisher));

            var existingPublisher = _publishers.FirstOrDefault(p => p.Id == publisher.Id);
            if (existingPublisher != null)
            {
                existingPublisher.Name = publisher.Name;
                existingPublisher.Headquarters = publisher.Headquarters;
                existingPublisher.Website = publisher.Website;
                existingPublisher.Games = publisher.Games;
            }
        }
    }
}
