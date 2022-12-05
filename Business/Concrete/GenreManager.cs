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
    public class GenreManager : IGenreManager
    {
        private readonly IGenreDal _genreDal;

        public GenreManager(IGenreDal genreDal)
        {
            _genreDal = genreDal;
        }

        public void Add(Genre genre)
        {
            _genreDal.Add(genre);
        }

        public List<Genre> GetAllGenres()
        {
            return _genreDal.GetAll();
        }

        public Genre GetGenreById(int id)
        {
            return _genreDal.Get(x => x.Id == id);
        }

        public void Remove(Genre genre, int id)
        {
            var current = _genreDal.Get(x => x.Id == id);
            current.Name = genre.Name;
            _genreDal.Delete(current);
        }

        public void Update(Genre genre, int id)
        {
            var current = _genreDal.Get(x => x.Id == id);
            current.Name = genre.Name;
            _genreDal.Update(current);
        }
    }
}
