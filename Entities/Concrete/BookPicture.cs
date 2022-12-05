
using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class BookPicture : IEntity
    {
        public int Id { get; set; }
        public string PhotoURL { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
