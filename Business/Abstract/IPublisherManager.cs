using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPublisherManager
    {
        void Add(Publisher publisher);
        void Remove(Publisher publisher, int id);
        void Update(Publisher publisher, int id);
        List<Publisher> GetAllPublisher();
        Publisher GetPublisherById(int id);
    }
}
