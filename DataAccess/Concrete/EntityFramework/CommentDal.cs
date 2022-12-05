using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class CommentDal : EfEntityRepositoryBase<Comment, KibritBookDbContext>, ICommentDal
    {
        public List<CommentDTO> GetAllComment()
        {
            using var context = new KibritBookDbContext();

            var comments = context.Comments.Include(x => x.Book).ToList();

            List<CommentDTO> result = new();

            foreach (var comment in comments)
            {
                CommentDTO commentDTO = new()
                {
                    Id = comment.Id,
                    UserName = comment.UserName,
                    UserEmail = comment.UserEmail,
                    Review = comment.Review,
                    Ratings = comment.Ratings,
                    BookName = comment.Book.Name,
                    BookId = comment.BookId
                };
                result.Add(commentDTO);
            }

            return result;
        }
    }
}
