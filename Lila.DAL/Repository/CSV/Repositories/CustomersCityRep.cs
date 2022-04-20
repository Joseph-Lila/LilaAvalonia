using Lila.DAL.Entities;
using Lila.DAL.Repository.CSV.Contexts;
using Lila.DAL.Logging;

namespace Lila.DAL.Repository.CSV.Repositories
{
    public class CustomersCityRep : IRepository<CustomersCity>
    {
        private CustomersCityContext db;

        private bool disposed = false;

        public CustomersCityRep(string path, BaseLogger logger)
        {
            db = new CustomersCityContext(path, logger);
        }

        public void Create(CustomersCity item)
        {
            db.Collection.Add(item);
        }

        public void Delete(int id)
        {
            CustomersCity item = db.Collection.Find(x => x.Id == id);
            if (item != null)
                db.Collection.Remove(item);
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
