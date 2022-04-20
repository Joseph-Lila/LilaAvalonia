using Lila.DAL.Entities;
using Lila.DAL.Repository.CSV.Contexts;
using Lila.DAL.Logging;

namespace Lila.DAL.Repository.CSV.Repositories
{
    public class UserRep : IRepository<User>
    {
        private UserContext db;

        private bool disposed = false;

        public UserRep(string path, BaseLogger logger)
        {
            db = new UserContext(path, logger);
        }

        public void Create(User item)
        {
            db.Collection.Add(item);
        }

        public void Delete(int id)
        {
            User item = db.Collection.Find(x => x.Id == id);
            if (item != null)
                db.Collection.Remove(item);
        }

        public List<User> GetCollection()
        {
            return db.Collection;
        }

        public User GetItem(int id)
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

        public void Update(User old, User @new)
        {
            int index = db.Collection.IndexOf(db.Collection.Find(x => x.Id == old.Id));
            db.Collection[index] = @new;
        }
    }
}
