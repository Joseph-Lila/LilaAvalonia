using Lila.DAL.Entities;
using Lila.DAL.Repository.SQLite.Contexts;
using Lila.DAL.Logging;

namespace Lila.DAL.Repository.SQLite.Repositories
{
    public class CustomerRep : IRepository<Customer>
    {
        private CustomerContext db;

        private bool disposed = false;

        public CustomerRep(string connectionString, BaseLogger logger)
        {
            db = new CustomerContext(connectionString, logger);
        }

        public void Create(Customer item)
        {
            db.Collection.Add(item);
        }

        public void Delete(int id)
        {
            Customer customer = db.Collection.Find(x => x.Id == id);
            if (customer != null)
                db.Collection.Remove(customer);
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
