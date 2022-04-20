using Lila.DAL.Entities;
using Lila.DAL.Repository.SQLite.Contexts;
using Lila.DAL.Logging;

namespace Lila.DAL.Repository.SQLite.Repositories
{
    public class CustomersCityRep : IRepository<CustomersCity>
    {
        private CustomersCityContext db;

        private bool disposed = false;

        public CustomersCityRep(string connectionString, BaseLogger logger)
        {
            db = new CustomersCityContext(connectionString, logger);
        }

        public void Create(CustomersCity item)
        {
            db.Collection.Add(item);
        }

        public void Delete(int id)
        {
            CustomersCity customersCity = db.Collection.Find(x => x.Id == id);
            if (customersCity != null)
                db.Collection.Remove(customersCity);
        }

        public List<CustomersCity> GetCollection()
        {
            return db.Collection;
        }

        public CustomersCity GetItem(int id)
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

        public void Update(CustomersCity old, CustomersCity @new)
        {
            int index = db.Collection.IndexOf(db.Collection.Find(x => x.Id == old.Id));
            db.Collection[index] = @new;
        }
    }
}
