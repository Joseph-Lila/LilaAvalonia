using Lila.DAL.Entities;
using Lila.DAL.Logging;


namespace Lila.DAL.Repository.CSV.Contexts
{
    public class CityContext : BaseContext<City>
    {
        public CityContext(string path, BaseLogger logger) : base(path, logger) { }
        public override void SaveChanges()
        {
            base.SaveChanges();
            // if id == 0, add it after all the changes
            // else delete all and add all with id != 0
            IEnumerable<City> readyToAdd =
                from el in Collection
                where el.Id != 0
                select el;
            IEnumerable<City> preparedToAdd =
                from el in Collection
                where el.Id == 0
                select el;
            DeleteAllRecords();
            AddReadyRecords(readyToAdd);
            AddPreparedRecords(preparedToAdd);
        }
        protected override void LoadData()
        {
            base.LoadData();
            StreamReader sr = new StreamReader(path);
            string line;
            string[] row = new string[2];
            while ((line = sr.ReadLine()) != null)
            {
                row = line.Split(';');
                int CityId = int.Parse(row[0]);
                string Title = row[1];
                City city = new City();
                city.Id = CityId;
                city.Title = Title;
                Collection.Add(city);
            }
        }
        protected override void DeleteAllRecords()
        {
            base.DeleteAllRecords();
            using (StreamWriter writer = new StreamWriter(path, false)) { }
        }
        protected override void AddReadyRecords(IEnumerable<City> collection)
        {
            base.AddReadyRecords(collection);
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                foreach (City c in collection)
                {
                    string strToAdd = $"{c.Id};{c.Title}";
                    writer.WriteLine(strToAdd);
                }
            }
        }
        protected override void AddPreparedRecords(IEnumerable<City> collection)
        {
            base.AddPreparedRecords(collection);
            int maxId = getMaxId();
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                foreach (City c in collection)
                {
                    string strToAdd = $"{++maxId};{c.Title}";
                    writer.WriteLine(strToAdd);
                }
            }
        }
    }
}
