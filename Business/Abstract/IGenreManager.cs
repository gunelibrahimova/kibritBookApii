using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IGenreManager
    {
        void Add(Genre genre);
        void Remove(Genre genre, int id);
        void Update(Genre genre, int id);
        List<Genre> GetAllGenres();
        Genre GetGenreById(int id);
    }
}
