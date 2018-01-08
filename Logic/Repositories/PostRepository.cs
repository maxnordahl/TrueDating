using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Repositories
{
    public class PostRepository : Repository<Post, int>
    {
        public PostRepository(ApplicationDbContext context) : base(context)
        {

        }

        public List<Post> GetAllForUser(string id)
        {
            return Items.Where(post => post.To_Id == id).ToList();
        }
    }
}
