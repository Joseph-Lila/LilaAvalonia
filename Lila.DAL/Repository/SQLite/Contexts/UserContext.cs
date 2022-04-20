using Lila.DAL.Entities;
using System.Data.SQLite;
using Lila.DAL.Logging;

namespace Lila.DAL.Repository.SQLite.Contexts
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
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sqlExpression = "SELECT * FROM User";
                Logger.LogSmth($"<<Data loaded >>\n\t\t{sqlExpression}");
                SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read())   // построчно считываем данные
                        {
                            int UserId = reader.GetInt32(0);
                            string Login = reader.GetString(1);
                            string Password = reader.GetString(2);
                            string Email = reader.GetString(3);
                            string PhoneNumber = reader.GetString(4);

                            User user = new User();
                            user.Id = UserId;
                            user.Login = Login;
                            user.Password = Password;
                            user.Email = Email;
                            user.PhoneNumber = PhoneNumber;

                            Collection.Add(user);
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
                string clearSqlExpression = "DELETE FROM User";
                Logger.LogSmth($"<<All records were deleted >>\n\t\t{clearSqlExpression}");
                SQLiteCommand deleteCommand = new SQLiteCommand(clearSqlExpression, connection);
                int number = deleteCommand.ExecuteNonQuery();
            }
        }

        protected override void AddReadyRecords(IEnumerable<User> collection)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                foreach (User c in collection)
                {
                    string sqlExpression = $"INSERT INTO User (UserId, Login, Password, Email, PhoneNumber) VALUES ({c.Id}, '{c.Login}', '{c.Password}', '{c.Email}', '{c.PhoneNumber}')";
                    Logger.LogSmth($"<<Records with correct Id were added >>\n\t\t{sqlExpression}");
                    SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
                    int number = command.ExecuteNonQuery();
                }
            }
        }

        protected override void AddPreparedRecords(IEnumerable<User> collection)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                foreach (User c in collection)
                {
                    string sqlExpression = $"INSERT INTO User (Login, Password, Email, PhoneNumber) VALUES ('{c.Login}', '{c.Password}', '{c.Email}', '{c.PhoneNumber}')";
                    Logger.LogSmth($"<<New records were added >>\n\t\t{sqlExpression}");
                    SQLiteCommand command = new SQLiteCommand(sqlExpression, connection);
                    int number = command.ExecuteNonQuery();
                }
            }
        }
    }
}
