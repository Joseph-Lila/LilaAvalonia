using Lila.DAL.Entities;
using Lila.DAL.Repository.SQLite.Contexts;
using Lila.DAL.Logging;

namespace Lila.DAL.Repository.SQLite.Repositories
{
    public class CityRep : IRepository<City>
    {
        private CityContext db;

        private bool disposed = false;

        public CityRep(string connectionString, BaseLogger logger)
        {
            db = new CityContext(connectionString, logger);
        }

        public void Create(City item)
        {
            db.Collection.Add(item);
        }

        public void Delete(int id)
        {
            City city = db.Collection.Find(x => x.Id == id);
            if (city != null)
                db.Collection.Remove(city);
        }

        public List<City> GetCollection()
        {
            return db.Collection;
        }

        public City GetItem(int id)
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

        public void Update(City old, City @new)
        {
            int index = db.Collection.IndexOf(db.Collection.Find(x => x.Id == old.Id));
            db.Collection[index] = @new;
        }
    }
}
