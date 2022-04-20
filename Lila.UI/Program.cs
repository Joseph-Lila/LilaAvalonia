using Lila.DAL.Logging;
using Lila.UI.Menu;

string? projectDirectory = Directory.GetParent(Environment.CurrentDirectory)?.Parent?.Parent?.Parent?.FullName;

string logPath = projectDirectory + "/Lila.UI/DataSources/logs.txt";
string sqliteDb = $"Data source={projectDirectory}/Lila.UI/DataSources/SqLite/sqlite.db";
string csvBeginPath = projectDirectory + "/Lila.UI/DataSources/CSV/";

MenuMaster menuMaster;
BaseLogger logger = new TxtLogger(logPath);
int sourceId = MenuMaster.ChooseSource();
if (sourceId == 1)
{
    menuMaster = new MenuMaster(
        new Lila.DAL.Repository.CSV.Repositories.CityRep(csvBeginPath + "City.csv", logger),
        new Lila.DAL.Repository.CSV.Repositories.CustomerRep(csvBeginPath + "Customer.csv", logger),
        new Lila.DAL.Repository.CSV.Repositories.CustomersCityRep(csvBeginPath + "CustomersCity.csv", logger),
        new Lila.DAL.Repository.CSV.Repositories.UserRep(csvBeginPath + "User.csv", logger)
    );
}
else
{
    menuMaster = new MenuMaster(
        new Lila.DAL.Repository.SQLite.Repositories.CityRep(sqliteDb, logger),
        new Lila.DAL.Repository.SQLite.Repositories.CustomerRep(sqliteDb, logger),
        new Lila.DAL.Repository.SQLite.Repositories.CustomersCityRep(sqliteDb, logger),
        new Lila.DAL.Repository.SQLite.Repositories.UserRep(sqliteDb, logger)
    );
}
menuMaster.MainProcessing();