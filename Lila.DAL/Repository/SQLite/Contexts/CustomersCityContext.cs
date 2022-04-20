using Lila.DAL.Entities;
using System.Data.SQLite;
using Lila.DAL.Logging;

namespace Lila.DAL.Repository.SQLite.Contexts
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
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sqlExpression = "SELECT * FROM CustomersCity";
                Logger.LogSmth($"<<Data loaded >>\n\t\t{sqlExpression}");
                SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read())   // построчно считываем данные
                        {
                            int CustomersCityId = reader.GetInt32(0);
                            int CustomerId = reader.GetInt32(1);
                            int CityId = reader.GetInt32(2);

                            CustomersCity customersCity = new CustomersCity();
                            customersCity.Id = CustomersCityId;
                            customersCity.CustomerId = CustomerId;
                            customersCity.CityId = CityId;

                            Collection.Add(customersCity);
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
                string clearSqlExpression = "DELETE FROM CustomersCity";
                Logger.LogSmth($"<<All records were deleted >>\n\t\t{clearSqlExpression}");
                SQLiteCommand deleteCommand = new SQLiteCommand(clearSqlExpression, connection);
                int number = deleteCommand.ExecuteNonQuery();
            }
        }

        protected override void AddReadyRecords(IEnumerable<CustomersCity> collection)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                foreach (CustomersCity c in collection)
                {
                    string sqlExpression = $"INSERT INTO CustomersCity (CustomersCityId, CustomerId, CityId) VALUES ({c.Id}, {c.CustomerId}, {c.CityId})";
                    Logger.LogSmth($"<<Records with correct Id were added >>\n\t\t{sqlExpression}");
                    SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
                    int number = command.ExecuteNonQuery();
                }
            }
        }

        protected override void AddPreparedRecords(IEnumerable<CustomersCity> collection)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                foreach (CustomersCity c in collection)
                {
                    string sqlExpression = $"INSERT INTO CustomersCity (CustomerId, CityId) VALUES ({c.CustomerId}, {c.CityId})";
                    Logger.LogSmth($"<<New records were added >>\n\t\t{sqlExpression}");
                    SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
                    int number = command.ExecuteNonQuery();
                }
            }
        }
    }
}
