using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Repository<TValue, TKey> where TValue : class, IEntity<TKey>
    {
        private readonly ApplicationDbContext context = new ApplicationDbContext();

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public DbSet<TValue> Items => context.Set<TValue>();

        public List<TValue> GetAll()
        {
            return Items.ToList();
        }

        public TValue Get(TKey id)
        {
            return Items.Find(id);
        }

        public void Add(TValue item)
        {
            Items.Add(item);
        }

        public void Delete(TKey id)
        {
            var item = this.Get(id);
            Items.Remove(item);
        }

        public void Save()
        {
            context.SaveChanges();
        }


    }
}
