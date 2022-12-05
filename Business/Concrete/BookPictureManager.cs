using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class BookPictureManager : IBookPictureManager
    {
        private readonly IBookPictureDal _bookPictureDal;

        public BookPictureManager(IBookPictureDal bookPictureDal)
        {
            _bookPictureDal = bookPictureDal;
        }

        public void AddBookPicture(BookPictureDTO productPicture)
        {
            BookPicture picture = new()
            {
                BookId = productPicture.BookId,
                PhotoURL = productPicture.PhotoURL,
            };
            _bookPictureDal.Add(picture);

        }
    }
}
