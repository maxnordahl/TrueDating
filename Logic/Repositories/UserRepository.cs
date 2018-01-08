using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Repositories
{
    public class UserRepository : Repository<ApplicationUser, string>
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
