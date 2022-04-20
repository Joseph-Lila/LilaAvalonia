using Lila.DAL.Logging;

namespace Lila.DAL.Repository.SQLite.Contexts
{
    public class BaseContext<T> : IDisposable where T : class
    {
        public List<T> Collection { get; set; }
        protected BaseLogger Logger { get; set; }

        protected string connectionString;

        public BaseContext(string connectionString, BaseLogger logger)
        {
            Collection = new List<T>();
            this.connectionString = connectionString;
            this.Logger = logger;
            LoadData();
        }

        public virtual void SaveChanges() { }

        protected virtual void LoadData() { }

        protected virtual void DeleteAllRecords() { }

        protected virtual void AddReadyRecords(IEnumerable<T> collection) { }

        protected virtual void AddPreparedRecords(IEnumerable<T> collection) { }

        public void Dispose() { }
    }
}
