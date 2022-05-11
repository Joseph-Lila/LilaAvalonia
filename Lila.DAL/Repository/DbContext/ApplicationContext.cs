using Lila.Domain;
using Microsoft.EntityFrameworkCore;

namespace Lila.DAL.Repository.DbContext;

public class ApplicationContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<City> Cities { get; set; } = null!;
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<CustomersCity> CustomersCities { get; set; } = null!;
    public DbSet<Employee> Employees { get; set; } = null!;
    public DbSet<Fleet> Fleets { get; set; } = null!;
    public DbSet<MyOrder> MyOrders { get; set; } = null!;
    public DbSet<OrdersService> OrdersServices { get; set; } = null!;
    public DbSet<OrdersTransport> OrdersTransports { get; set; } = null!;
    public DbSet<Role> Roles { get; set; } = null!;
    public DbSet<Service> Services { get; set; } = null!;
    public DbSet<Stage> Stages { get; set; } = null!;
    public DbSet<Status> Statuses { get; set; } = null!;
    public DbSet<Transport> Transports { get; set; } = null!;
    public DbSet<TransportsKind> TransportsKinds { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<UsersRole> UsersRoles { get; set; } = null!;

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>().HasData(
            new City { Id = 1, Title = "Варанаси" },
            new City { Id = 2, Title = "Гомель" },
            new City { Id = 3, Title = "Дели" },
            new City { Id = 4, Title = "Минск" },
            new City { Id = 5, Title = "Москва" },
            new City { Id = 6, Title = "Лос-Анджелес" },
            new City { Id = 7, Title = "Бразилиа" }
        );
        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Login = "director", Password = "123", Email = "director@art", PhoneNumber = "+375XXXXXXXXX"},
            new User { Id = 2, Login = "courier", Password = "123", Email = "courier@art", PhoneNumber = "+375XXXXXXXXX"},
            new User { Id = 3, Login = "operator", Password = "123", Email = "operator@art", PhoneNumber = "+375XXXXXXXXX"}
        );
        modelBuilder.Entity<Customer>().HasData(
            new Customer { Id = 1, UserId = 1, Country = "Индия", Street = "XXX", HomeNumber = 49, FlatNumber = 8, LastName = "Last1", Name = "Name1", MiddleName = "Middle1"},
            new Customer { Id = 2, UserId = 2, Country = "Индия", Street = "XXX", HomeNumber = 49, FlatNumber = 8, LastName = "Last2", Name = "Name2", MiddleName = "Middle2"},
            new Customer { Id = 3, UserId = 3, Country = "Индия", Street = "XXX", HomeNumber = 49, FlatNumber = 8, LastName = "Last3", Name = "Name3", MiddleName = "Middle3"}
        );
        modelBuilder.Entity<CustomersCity>().HasData(
            new CustomersCity { Id = 1, CityId = 3, CustomerId = 1},
            new CustomersCity { Id = 2, CityId = 1, CustomerId = 2},
            new CustomersCity { Id = 3, CityId = 1, CustomerId = 3}
        );
        modelBuilder.Entity<Role>().HasData(
            new Role { Id = 1, Title = "Customer", Description = "Заказывает услуги."},
            new Role { Id = 2, Title = "Director", Description = "Ведет справочники, прейскурант, наблюдает отчетность."},
            new Role { Id = 3, Title = "Operator", Description = "Распределяет оплаченные заказы между курьерами."},
            new Role { Id = 4, Title = "Courier", Description = "Выполняет заказы."}
        );
        modelBuilder.Entity<UsersRole>().HasData(
            new UsersRole { Id = 1, UserId = 1, RoleId = 2},
            new UsersRole { Id = 2, UserId = 2, RoleId = 4},
            new UsersRole { Id = 3, UserId = 3, RoleId = 3}
        );
        modelBuilder.Entity<Status>().HasData(
            new Status { Id = 1, Title = "Оплачен", Description = "Заказ оплачен клиентом и отмена невозможна."},
            new Status { Id = 2, Title = "Не оплачен", Description = "Заказ не оплачен и может быть отменен."},
            new Status { Id = 3, Title = "Занят", Description = "Сотрудник недоступен."},
            new Status { Id = 4, Title = "Свободен", Description = "Сотрудник доступен и ему можно поручить задание."}
        );
        modelBuilder.Entity<Stage>().HasData(
            new Stage { Id = 1, Title = "Выполняется", Description = "Заказ в процессе выполнения."},
            new Stage { Id = 2, Title = "На рассмотрении", Description = "Заказ оплачен и должен быть поручен свободному курьеру."},
            new Stage { Id = 3, Title = "Отменен", Description = "Заказ не был оплачен и был отменен клиентом."},
            new Stage { Id = 4, Title = "Выполнен", Description = "Заказ успешно выполнен."}
        );
        modelBuilder.Entity<Employee>().HasData(
            new Employee { Id = 1, UserId = 1, PassportData = "XXXXXXX", Salary = 100000, Requirements = "requirements1", Duties = "duties1", StatusId = 4},
            new Employee { Id = 2, UserId = 2, PassportData = "XXXXXXX", Salary = 100000, Requirements = "requirements2", Duties = "duties2", StatusId = 4},
            new Employee { Id = 3, UserId = 3, PassportData = "XXXXXXX", Salary = 100000, Requirements = "requirements3", Duties = "duties3", StatusId = 4}
        );
        modelBuilder.Entity<TransportsKind>().HasData(
            new TransportsKind { Id = 1, Description = "description1", Title = "Бортовой грузовик", LiftingCapacity = 8000, Volume = 12.5},
            new TransportsKind { Id = 2, Description = "description2", Title = "Фургон", LiftingCapacity = 2360, Volume = 11.5},
            new TransportsKind { Id = 3, Description = "description3", Title = "Рефрижератор", LiftingCapacity = 4000, Volume = 24},
            new TransportsKind { Id = 4, Description = "description4", Title = "Самосвал", LiftingCapacity = 3500, Volume = 24}
        );
        modelBuilder.Entity<Fleet>().HasData(
            new Fleet {Id = 1, Title = "ПА-1", Description = "description1", Address = "street1", Square = 300, StarsQuantity = 4, CityId = 1},
            new Fleet {Id = 2, Title = "ПА-2", Description = "description2", Address = "street2", Square = 100, StarsQuantity = 3, CityId = 1}
        );
        modelBuilder.Entity<Transport>().HasData(
            new Transport { Id = 1, TransportsKindId = 1, FleetId = 1},
            new Transport { Id = 2, TransportsKindId = 3, FleetId = 2},
            new Transport { Id = 3, TransportsKindId = 2, FleetId = 1},
            new Transport { Id = 4, TransportsKindId = 4, FleetId = 2}
        );
        modelBuilder.Entity<Service>().HasData(
            new Service { Id = 1, Title = "Перевозка сборных грузов", Description = "description1", CostWeight = 5, CostRadius = 5, ImageLink = "https://s0.rbk.ru/v6_top_pics/media/img/9/89/756003521970899.jpg"},
            new Service { Id = 2, Title = "Вывоз строительного и бытового мусора", Description = "description2", CostWeight = 7, CostRadius = 3, ImageLink = "https://images.prom.ua/417178807_legendarnyj-gruzovik-shockwave.jpg"},
            new Service { Id = 3, Title = "Грузоперевозки", Description = "description3", CostWeight = 4, CostRadius = 6, ImageLink = "https://wrc-info.ru/uploads/posts/2020-01/1578054173_inx960x640.jpg"},
            new Service { Id = 4, Title = "Специальные грузоперевозки", Description = "description4", CostWeight = 5, CostRadius = 10, ImageLink = "https://perevozka24.ru/img/ck_upload/chto-takoe-specialnye-gruzy.jpg"}
        );
        modelBuilder.Entity<MyOrder>().HasData(
            new MyOrder { Id = 1, Commissions = DateTime.Now, Executions = DateTime.Now, CourierId = 1, CustomerId = 1, OperatorId = 1, StageId = 4, StatusId = 1}
        );
        modelBuilder.Entity<OrdersService>().HasData(
            new OrdersService { Id = 1, ServiceId = 3, MyOrderId = 1, QuantityWeight = 10, QuantityRadius = 10, DestinationsAddress = "address1", DeparturesAddress = "address2", TotalCost = 100, BeginCityId = 1, EndCityId = 3}
        );
        modelBuilder.Entity<OrdersTransport>().HasData(
            new OrdersTransport { Id = 1, TransportId = 1, MyOrderId = 1}
        );
    }
}