using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Core.Entity.Models;
using DataAccess.Abstract;

namespace DataAccess.Concrete.EntityFramework
{
    public class AuthDal : EfEntityRepositoryBase<User, KibritBookDbContext>, IAuthDal
    {
    }
}
