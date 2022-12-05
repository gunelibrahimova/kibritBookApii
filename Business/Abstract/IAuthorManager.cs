using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthorManager
    {
        void Add(Author author);
        void Remove(Author author, int id);
        void Update(Author author, int id);
        List<Author> GetAllAuthor();
        Author GetAuthorById(int id);
    }
}
