using Lila.DAL.Entities;
using System.Data.SQLite;
using Lila.DAL.Logging;

namespace Lila.DAL.Repository.SQLite.Contexts
{
    public class CityContext : BaseContext<City>
    {
        public CityContext(string path, BaseLogger logger) : base(path, logger) { }

        public override void SaveChanges()
        {
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
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sqlExpression = "SELECT * FROM City";
                Logger.LogSmth($"<<Data loaded >>\n\t\t{sqlExpression}");
                SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read())   // построчно считываем данные
                        {
                            int CityId = reader.GetInt32(0);
                            string Title = reader.GetString(1);

                            City city = new City();
                            city.Id = CityId;
                            city.Title = Title;

                            Collection.Add(city);
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
                string clearSqlExpression = "DELETE FROM City";
                Logger.LogSmth($"<<All records were deleted >>\n\t\t{clearSqlExpression}");
                SQLiteCommand deleteCommand = new SQLiteCommand(clearSqlExpression, connection);
                int number = deleteCommand.ExecuteNonQuery();
            }
        }

        protected override void AddReadyRecords(IEnumerable<City> collection)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                foreach (City c in collection)
                {
                    string sqlExpression = $"INSERT INTO City (CityId, Title) VALUES ({c.Id}, '{c.Title}')";
                    Logger.LogSmth($"<<Records with correct Id were added >>\n\t\t{sqlExpression}");
                    SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
                    int number = command.ExecuteNonQuery();
                }
            }
        }

        protected override void AddPreparedRecords(IEnumerable<City> collection)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                foreach (City c in collection)
                {
                    string sqlExpression = $"INSERT INTO City (Title) VALUES ('{c.Title}')";
                    Logger.LogSmth($"<<New records were added >>\n\t\t{sqlExpression}");
                    SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
                    int number = command.ExecuteNonQuery();
                }
            }
        }
    }
}
