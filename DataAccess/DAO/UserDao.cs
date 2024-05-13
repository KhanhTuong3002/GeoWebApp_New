using BusinessObject.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class UserDao (DbContext dbContext) : BaseDao<User>(dbContext)
    {
    }
}
