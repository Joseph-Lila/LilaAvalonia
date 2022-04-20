using Lila.DAL.Entities;
using Lila.DAL.Logging;

namespace Lila.DAL.Repository.CSV.Contexts
{
    public class CustomersCityContext : BaseContext<CustomersCity>
    {
        public CustomersCityContext(string path, BaseLogger logger) : base(path, logger) { }

        public override void SaveChanges()
        {
            // if id == 0, add it after all the changes
            // else delete all and add all with id != 0
            IEnumerable<CustomersCity> readyToAdd =
                from el in Collection
                where el.Id != 0
                select el;
            IEnumerable<CustomersCity> preparedToAdd =
                from el in Collection
                where el.Id == 0
                select el;
            DeleteAllRecords();
            AddReadyRecords(readyToAdd);
            AddPreparedRecords(preparedToAdd);
        }

        protected override void LoadData()
        {
            StreamReader sr = new StreamReader(path);
            string line;
            string[] row = new string[3];
            while ((line = sr.ReadLine()) != null)
            {
                row = line.Split(';');
                int Id = int.Parse(row[0]);
                int CustomerId = int.Parse(row[1]);
                int CityId = int.Parse(row[2]);
                CustomersCity item = new CustomersCity();
                item.Id = Id;
                item.CustomerId = CustomerId;
                item.CityId = CityId;
                Collection.Add(item);
            }
        }

        protected override void DeleteAllRecords()
        {
            using (StreamWriter writer = new StreamWriter(path, false)) { }
        }

        protected override void AddReadyRecords(IEnumerable<CustomersCity> collection)
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                foreach (CustomersCity c in collection)
                {
                    string strToAdd = $"{c.Id};{c.CustomerId};{c.CityId}";
                    writer.WriteLine(strToAdd);
                }
            }
        }

        protected override void AddPreparedRecords(IEnumerable<CustomersCity> collection)
        {
            int maxId = getMaxId();
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                foreach (CustomersCity c in collection)
                {
                    string strToAdd = $"{++maxId};{c.CustomerId};{c.CityId}";
                    writer.WriteLine(strToAdd);
                }
            }
        }
    }
}
