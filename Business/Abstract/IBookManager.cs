using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IBookManager
    {
        void AddBook(AddBookDTO bookDTO);
        void UpdateBook(AddBookDTO bookDTO, int id);
        void RemoveBook(AddBookDTO bookDTO, int id);
        List<BookDTO> GetAllBookList();
        BookDTO GetBookById(int id);
    }
}
