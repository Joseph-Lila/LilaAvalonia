using Lila.DAL.Entities;
using System.Data.SQLite;
using Lila.DAL.Logging;

namespace Lila.DAL.Repository.SQLite.Contexts
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
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sqlExpression = "SELECT * FROM Customer";
                Logger.LogSmth($"<<Data loaded >>\n\t\t{sqlExpression}");
                SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read())   // построчно считываем данные
                        {
                            int CustomerId = reader.GetInt32(0);
                            int UserId = reader.GetInt32(1);
                            string Country = reader.GetString(2);
                            string Street = reader.GetString(3);
                            int HomeNumber = reader.GetInt32(4);
                            int FlatNumber = reader.GetInt32(5);
                            string LastName = reader.GetString(6);
                            string Name = reader.GetString(7);
                            string MiddleName = reader.GetString(8);

                            Customer customer = new Customer();
                            customer.Id = CustomerId;
                            customer.UserId = UserId;
                            customer.Country = Country;
                            customer.Street = Street;
                            customer.HomeNumber = HomeNumber;
                            customer.FlatNumber = FlatNumber;
                            customer.LastName = LastName;
                            customer.Name = Name;
                            customer.MiddleName = MiddleName;

                            Collection.Add(customer);
                        }
                    }
                }
            }
        }

        protected override void DeleteAllRecords()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string clearSqlExpression = "DELETE FROM Customer";
                Logger.LogSmth($"<<All records were deleted >>\n\t\t{clearSqlExpression}");
                SQLiteCommand deleteCommand = new SQLiteCommand(clearSqlExpression, connection);
                int number = deleteCommand.ExecuteNonQuery();
            }
        }

        protected override void AddReadyRecords(IEnumerable<Customer> collection)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                foreach (Customer c in collection)
                {
                    string sqlExpression = $"INSERT INTO Customer (CustomerId, UserId, Country, Street, HomeNumber, FlatNumber, LastName, Name, MiddleName) VALUES ({c.Id}, {c.UserId}, '{c.Country}', '{c.Street}', {c.HomeNumber}, {c.FlatNumber}, '{c.LastName}', '{c.Name}', '{c.MiddleName}')";
                    Logger.LogSmth($"<<Records with correct Id were added >>\n\t\t{sqlExpression}");
                    SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
                    int number = command.ExecuteNonQuery();
                }
            }
        }

        protected override void AddPreparedRecords(IEnumerable<Customer> collection)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                foreach (Customer c in collection)
                {
                    string sqlExpression = $"INSERT INTO Customer (UserId, Country, Street, HomeNumber, FlatNumber, LastName, Name, MiddleName) VALUES ({c.UserId}, '{c.Country}', '{c.Street}', {c.HomeNumber}, {c.FlatNumber}, '{c.LastName}', '{c.Name}', '{c.MiddleName}')";
                    Logger.LogSmth($"<<New records were added >>\n\t\t{sqlExpression}");
                    SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
                    int number = command.ExecuteNonQuery();
                }
            }
        }
    }
}
