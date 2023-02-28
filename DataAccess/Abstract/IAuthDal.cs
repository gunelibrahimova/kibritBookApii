using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Core.Entity.Models;

namespace DataAccess.Abstract
{
    public interface IAuthDal : IEntityRepository<User>
    {
    }
}
