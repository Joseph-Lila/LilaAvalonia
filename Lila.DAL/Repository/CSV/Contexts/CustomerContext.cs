using Lila.DAL.Entities;
using Lila.DAL.Logging;

namespace Lila.DAL.Repository.CSV.Contexts
{
    public class CustomerContext : BaseContext<Customer>
    {
        public CustomerContext(string path, BaseLogger logger) : base(path, logger) { }

        public override void SaveChanges()
        {
            // if id == 0, add it after all the changes
            // else delete all and add all with id != 0
            IEnumerable<Customer> readyToAdd =
                from el in Collection
                where el.Id != 0
                select el;
            IEnumerable<Customer> preparedToAdd =
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
            string[] row = new string[9];
            while ((line = sr.ReadLine()) != null)
            {
                row = line.Split(';');
                int Id = int.Parse(row[0]);
                int UserId = int.Parse(row[1]);
                string Country = row[2];
                string Street = row[3];
                int HomeNumber = int.Parse(row[4]);
                int FlatNumber = int.Parse(row[5]);
                string LastName = row[6];
                string Name = row[7];
                string MiddleName = row[8];
                Customer item = new Customer();
                item.Id = Id;
                item.UserId = UserId;
                item.Country = Country;
                item.Street = Street;
                item.HomeNumber = HomeNumber;
                item.FlatNumber = FlatNumber;
                item.LastName = LastName;
                item.Name = Name;
                item.MiddleName = MiddleName;
                Collection.Add(item);
            }
        }

        protected override void DeleteAllRecords()
        {
            using (StreamWriter writer = new StreamWriter(path, false)) { }
        }

        protected override void AddReadyRecords(IEnumerable<Customer> collection)
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                foreach (Customer c in collection)
                {
                    string strToAdd = $"{c.Id};{c.UserId};{c.Country};{c.Street};{c.HomeNumber};{c.FlatNumber};{c.LastName};{c.Name};{c.MiddleName}";
                    writer.WriteLine(strToAdd);
                }
            }
        }

        protected override void AddPreparedRecords(IEnumerable<Customer> collection)
        {
            int maxId = getMaxId();
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                foreach (Customer c in collection)
                {
                    string strToAdd = $"{++maxId};{c.UserId};{c.Country};{c.Street};{c.HomeNumber};{c.FlatNumber};{c.LastName};{c.Name};{c.MiddleName}";
                    writer.WriteLine(strToAdd);
                }
            }
        }
    }
}
