using GameSpot.BL.Interfaces;
using GameSpot.DL.Interfaces;
using GameSpot.Models;

namespace GameSpot.BL.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly IPublisherRepository _publisherRepository;

        public PublisherService(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository ?? throw new ArgumentNullException(nameof(publisherRepository));
        }

        public void Add(Publisher publisher)
        {
            if (publisher == null)
                throw new ArgumentNullException(nameof(publisher));

            _publisherRepository.Add(publisher);
        }

        public void Delete(int id)
        {
            _publisherRepository.Delete(id);
        }

        public IEnumerable<Publisher> GetAll()
        {
            return _publisherRepository.GetAll();
        }

        public Publisher GetById(int id)
        {
            return _publisherRepository.GetById(id);
        }

        public void Update(Publisher publisher)
        {
            if (publisher == null)
                throw new ArgumentNullException(nameof(publisher));

            _publisherRepository.Update(publisher);
        }
    }
}
