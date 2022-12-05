using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PublisherManager : IPublisherManager
    {

        private readonly IPublisherDal _publisherDal;

        public PublisherManager(IPublisherDal publisherDal)
        {
            _publisherDal = publisherDal;
        }

        public void Add(Publisher publisher)
        {
            _publisherDal.Add(publisher);
        }

        public List<Publisher> GetAllPublisher()
        {
            return _publisherDal.GetAll();
        }

        public Publisher GetPublisherById(int id)
        {
            return _publisherDal.Get(x => x.Id == id);
        }

        public void Remove(Publisher publisher, int id)
        {
            var current = _publisherDal.Get(x => x.Id == id);
            current.Name = publisher.Name;
            current.PhotoURL = publisher.PhotoURL;
            current.PublishDate = publisher.PublishDate;
            _publisherDal.Delete(current);
        }

        public void Update(Publisher publisher, int id)
        {
            var current = _publisherDal.Get(x => x.Id == id);
            current.Name = publisher.Name;
            current.PhotoURL = publisher.PhotoURL;
            current.PublishDate = publisher.PublishDate;
            _publisherDal.Update(current);
        }

    }
}
