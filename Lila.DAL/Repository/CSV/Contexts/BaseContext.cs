using Lila.DAL.Entities;
using Lila.DAL.Logging;

namespace Lila.DAL.Repository.CSV.Contexts
{
    public class BaseContext<T> : IDisposable where T : BaseEntity
    {
        public List<T> Collection { get; set; }
        protected BaseLogger Logger {get;}

        protected string path;

        public BaseContext(string path, BaseLogger logger)
        {
            Collection = new List<T>();
            this.path = path;
            this.Logger = logger;
            LoadData();
        }

        protected int getMaxId()
        {
            int maxId = 0;
            foreach (T c in Collection)
            {
                if (c.Id > maxId)
                    maxId = c.Id;
            }
            return maxId;
        }

        public virtual void SaveChanges()
        {
            Logger.LogSmth($"<<Changes saved ({typeof(T).Name})>>\n\t\tNo sql commands here...");
        }

        protected virtual void LoadData()
        {
            Logger.LogSmth($"<<Data loaded ({typeof(T).Name})>>\n\t\tNo sql commands here...");
        }

        protected virtual void DeleteAllRecords()
        {
            Logger.LogSmth($"<<All records were deleted ({typeof(T).Name})>>\n\t\tNo sql commands here...");
        }

        protected virtual void AddReadyRecords(IEnumerable<T> collection)
        {
            Logger.LogSmth($"<<Records with correct Id were added ({typeof(T).Name})>>\n\t\tNo sql commands here...");
        }

        protected virtual void AddPreparedRecords(IEnumerable<T> collection)
        {
            Logger.LogSmth($"<<New records were added ({typeof(T).Name})>>\n\t\tNo sql commands here...");
        }

        public void Dispose() { }
    }
}
