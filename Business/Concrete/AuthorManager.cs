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
    public class AuthorManager : IAuthorManager
    {
        private readonly IAuthorDal _authorDal;

        public AuthorManager(IAuthorDal authorDal)
        {
            _authorDal = authorDal;
        }

        public void Add(Author author)
        {
            _authorDal.Add(author);
        }

        public List<Author> GetAllAuthor()
        {
            return _authorDal.GetAll();
        }

        public Author GetAuthorById(int id)
        {
            return _authorDal.Get(x => x.Id == id);
        }
        public void Remove(Author author, int id)
        {
            var current = _authorDal.Get(x => x.Id == id);
            current.Name = author.Name;
            current.Description = author.Description;
            current.PhotoURL = author.PhotoURL;
            _authorDal.Delete(current);
        }
        public void Update(Author author, int id)
        {
            var current = _authorDal.Get(x => x.Id == id);
            current.Name = author.Name;
            current.Description = author.Description;
            current.PhotoURL = author.PhotoURL;
            _authorDal.Update(current);
        }
    }
}
