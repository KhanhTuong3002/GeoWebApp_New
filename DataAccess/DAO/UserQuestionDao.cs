using BusinessObject.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class UserQuestionDao : BaseDao<UserQuestion>
    {
        public UserQuestionDao(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
