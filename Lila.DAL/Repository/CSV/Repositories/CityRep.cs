using Lila.DAL.Entities;
using Lila.DAL.Repository.CSV.Contexts;
using Lila.DAL.Logging;

namespace Lila.DAL.Repository.CSV.Repositories
{
    public class CityRep : IRepository<City>
    {
        private CityContext db;

        private bool disposed = false;

        public CityRep(string path, BaseLogger logger)
        {
            db = new CityContext(path, logger);
        }

        public void Create(City item)
        {
            db.Collection.Add(item);
        }

        public void Delete(int id)
        {
            City item = db.Collection.Find(x => x.Id == id);
            if (item != null)
                db.Collection.Remove(item);
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
