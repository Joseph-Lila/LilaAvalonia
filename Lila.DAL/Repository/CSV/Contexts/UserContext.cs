using Lila.DAL.Entities;
using Lila.DAL.Logging;

namespace Lila.DAL.Repository.CSV.Contexts
{
    public class UserContext : BaseContext<User>
    {
        public UserContext(string path, BaseLogger logger) : base(path, logger) { }

        public override void SaveChanges()
        {
            // if id == 0, add it after all the changes
            // else delete all and add all with id != 0
            IEnumerable<User> readyToAdd =
                from el in Collection
                where el.Id != 0
                select el;
            IEnumerable<User> preparedToAdd =
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
            string[] row = new string[5];
            while ((line = sr.ReadLine()) != null)
            {
                row = line.Split(';');
                int Id = int.Parse(row[0]);
                string Login = row[1];
                string Password = row[2];
                string Email = row[3];
                string PhoneNumber = row[4];
                User item = new User();
                item.Id = Id;
                item.Login = Login;
                item.Password = Password;
                item.Email = Email;
                item.PhoneNumber = PhoneNumber;
                Collection.Add(item);
            }
        }

        protected override void DeleteAllRecords()
        {
            using (StreamWriter writer = new StreamWriter(path, false)) { }
        }

        protected override void AddReadyRecords(IEnumerable<User> collection)
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                foreach (User c in collection)
                {
                    string strToAdd = $"{c.Id};{c.Login};{c.Password};{c.Email};{c.PhoneNumber}";
                    writer.WriteLine(strToAdd);
                }
            }
        }

        protected override void AddPreparedRecords(IEnumerable<User> collection)
        {
            int maxId = getMaxId();
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                foreach (User c in collection)
                {
                    string strToAdd = $"{++maxId};{c.Login};{c.Password};{c.Email};{c.PhoneNumber}";
                    writer.WriteLine(strToAdd);
                }
            }
        }
    }
}
