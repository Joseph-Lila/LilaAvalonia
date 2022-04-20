using Lila.DAL.Entities;
using Lila.DAL.Repository.CSV.Contexts;
using Lila.DAL.Logging;

namespace Lila.DAL.Repository.CSV.Repositories
{
    public class CustomerRep : IRepository<Customer>
    {
        private CustomerContext db;

        private bool disposed = false;

        public CustomerRep(string path, BaseLogger logger)
        {
            db = new CustomerContext(path, logger);
        }

        public void Create(Customer item)
        {
            db.Collection.Add(item);
        }

        public void Delete(int id)
        {
            Customer item = db.Collection.Find(x => x.Id == id);
            if (item != null)
                db.Collection.Remove(item);
        }

        public List<Customer> GetCollection()
        {
            return db.Collection;
        }

        public Customer GetItem(int id)
        {
            return db.Collection.Find(x => x.Id == id);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Update(Customer old, Customer @new)
        {
            int index = db.Collection.IndexOf(db.Collection.Find(x => x.Id == old.Id));
            db.Collection[index] = @new;
        }
    }
}
