using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Repositories
{
    public class FriendRepository : Repository<Friends, int>
    {
        public FriendRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
