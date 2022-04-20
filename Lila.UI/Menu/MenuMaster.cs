using Lila.DAL.Entities;
using Lila.DAL.Repository;

namespace Lila.UI.Menu
{
    public class MenuMaster
    {
        private readonly IRepository<City> _cityRep;
        private readonly IRepository<Customer> _customerRep;
        private readonly IRepository<CustomersCity> _customersCityRep;
        private readonly IRepository<User> _userRep;

        public static int ChooseSource()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. CSV.");
                Console.WriteLine("2. SqLite.");
                int ans = Int32.Parse(Console.ReadLine() ?? string.Empty);
                if (ans >= 1 && ans <= 2)
                    return ans;
            }
        }
        public MenuMaster(
            IRepository<City> cityRep,
            IRepository<Customer> customerRep,
            IRepository<CustomersCity> customersCityRep,
            IRepository<User> userRep)
        {
            _cityRep = cityRep;
            _customerRep = customerRep;
            _customersCityRep = customersCityRep;
            _userRep = userRep;
        }
        private int MainOptions()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Поиск информации.");
                Console.WriteLine("2. Добавление информации.");
                Console.WriteLine("3. Удаление информации.");
                Console.WriteLine("4. Сохранить изменения.");
                Console.WriteLine("5. Выйти.");
                int ans = Int32.Parse(Console.ReadLine() ?? string.Empty);
                Console.Clear();
                if (ans >= 1 && ans <= 5)
                    return ans;
            }
        }
        public void MainProcessing()
        {
            bool flag = true;
            while (flag)
            {
                int ans = MainOptions();
                Console.Clear();
                switch (ans)
                {
                    case 1:
                    {
                        SearchProcessing();
                        Console.WriteLine("\nДля продолжения нажните на любую клавишу...");
                        Console.ReadKey();
                        break;
                    }
                    case 2:
                    {
                        AddingProcessing();
                        Console.WriteLine("\nДля продолжения нажните на любую клавишу...");
                        Console.ReadKey();
                        break;
                    }
                    case 3:
                    {
                        DeletingProcessing();
                        Console.WriteLine("\nДля продолжения нажните на любую клавишу...");
                        Console.ReadKey();
                        break;
                    }
                    case 4:
                    {
                        SaveChangesProcessing();
                        break;
                    }
                    case 5:
                    {
                        flag = false;
                        break;
                    }
                }
            }
        }
        private int SearchOptions()
        {
            while (true)
            {
                Console.Clear();                
                Console.WriteLine("1. Вывести города.");
                Console.WriteLine("2. Вывести город по заданному ID.");
                Console.WriteLine("3. Вывести клиентов.");
                Console.WriteLine("4. Вывести клиента по заданному ID.");
                Console.WriteLine("5. Вывести города клиентов.");
                Console.WriteLine("6. Вывести город клиента по заданному ID.");
                Console.WriteLine("7. Вывести пользователей.");
                Console.WriteLine("8. Вывести пользователя по заданному ID.");
                int ans = Int32.Parse(Console.ReadLine() ?? string.Empty);
                if (ans >= 1 && ans <= 8)
                    return ans;
            }
        }
        private int DeletingOptions()
        {
            while (true)
            {
                Console.Clear();                
                Console.WriteLine("1. Удалить город по заданному ID.");
                Console.WriteLine("2. Удалить клиента по заданному ID.");
                Console.WriteLine("3. Удалить город клиента по заданному ID.");
                Console.WriteLine("4. Удалить пользователя по заданному ID.");
                int ans = Int32.Parse(Console.ReadLine() ?? string.Empty);
                if (ans >= 1 && ans <= 4)
                    return ans;
            }
        }
        private int DeletingProcessingChoseId()
        {
            Console.Clear();
            Console.Write("Введите Id для удаления: ");
            int id = Int32.Parse(Console.ReadLine() ?? string.Empty);
            return id;
        }
        private void DeletingProcessing()
        {
            Console.Clear();
            int ans = DeletingOptions();
            Console.Clear();
            int id = DeletingProcessingChoseId();
            Console.Clear();
            switch (ans)
            {
                case 1:
                {
                    _cityRep.Delete(id);
                    break;
                }
                case 2:
                {
                    _customerRep.Delete(id);
                    break;
                }
                case 3:
                {
                    _customersCityRep.Delete(id);
                    break;
                }
                case 4:
                {
                    _userRep.Delete(id);
                    break;
                }
            }
        }
        private void SearchProcessing()
        {
            Console.Clear();
            int id;
            int ans = SearchOptions();
            Console.Clear();
            switch (ans)
            {
                case 1:
                {
                    _cityRep.GetCollection().ForEach(x => Console.WriteLine(x.ToString()));
                    break;
                }
                case 2:
                {
                    Console.WriteLine("Введите id:");
                    id = Int32.Parse(Console.ReadLine() ?? string.Empty);
                    Console.WriteLine(_cityRep.GetItem(id).ToString());
                    break;
                }
                case 3:
                {
                    _customerRep.GetCollection().ForEach(x => Console.WriteLine(x.ToString()));
                    break;
                }
                case 4:
                {
                    Console.WriteLine("Введите id:");
                    id = Int32.Parse(Console.ReadLine() ?? string.Empty); 
                    Console.WriteLine(_customerRep.GetItem(id).ToString());
                    break;
                }
                case 5:
                {
                    _customersCityRep.GetCollection().ForEach(x => Console.WriteLine(x.ToString()));
                    break;
                }
                case 6:
                {
                    Console.WriteLine("Введите id:");
                    id = Int32.Parse(Console.ReadLine() ?? string.Empty); 
                    Console.WriteLine(_customersCityRep.GetItem(id).ToString());
                    break;
                }
                case 7:
                {
                    _userRep.GetCollection().ForEach(x => Console.WriteLine(x.ToString()));
                    break;
                }
                case 8:
                {
                    Console.WriteLine("Введите id:");
                    id = Int32.Parse(Console.ReadLine() ?? string.Empty); 
                    Console.WriteLine(_userRep.GetItem(id).ToString());
                    break;
                }
            }
        }
        private int AddingOptions()
        {
            while (true)
            {
                Console.Clear();                
                Console.WriteLine("1. Добавить город.");
                Console.WriteLine("2. Добавить клиента.");
                Console.WriteLine("3. Добавить город клиента.");
                Console.WriteLine("4. Добавить пользователя.");
                int ans = Int32.Parse(Console.ReadLine() ?? string.Empty);
                if (ans >= 1 && ans <= 4)
                    return ans;
            }
        }
        private void CityAddingProcess()
        {
            Console.Write("Введите название нового города: ");
            string title = Console.ReadLine();
            City city = new City
            {
                Title = title,
                Id = 0
            };
            _cityRep.Create(city);
        }
        private void CustomerAddingProcess()
        {
            Console.Write("Введите UserId: ");
            int userId = Int32.Parse(Console.ReadLine() ?? string.Empty);
            Console.Write("Введите страну: ");
            string country = Console.ReadLine();
            Console.Write("Введите улицу: ");
            string street = Console.ReadLine();
            Console.Write("Введите номер дома: ");
            int homeNumber = Int32.Parse(Console.ReadLine() ?? string.Empty);
            Console.Write("Введите номер квартиры: ");
            int flatNumber = Int32.Parse(Console.ReadLine() ?? string.Empty);
            Console.Write("Введите отчество: ");
            string lastName = Console.ReadLine();
            Console.Write("Введите имя: ");
            string name = Console.ReadLine();
            Console.Write("Введите фамилию: ");
            string middleName = Console.ReadLine();
            Customer customer = new Customer
            {
                Id = 0,
                UserId = userId,
                Country = country,
                Street = street,
                HomeNumber = homeNumber,
                FlatNumber = flatNumber,
                LastName = lastName,
                Name = name,
                MiddleName = middleName
            };
            _customerRep.Create(customer);
        }
        private void CustomersCityAddingProcess()
        {
            Console.Write("Введите CustomerId: ");
            int customerId = Int32.Parse(Console.ReadLine() ?? string.Empty);
            Console.Write("Введите CityId: ");
            int cityId = Int32.Parse(Console.ReadLine() ?? string.Empty);
            CustomersCity customersCity = new CustomersCity
            {
                Id = 0,
                CustomerId = customerId,
                CityId = cityId
            };
            _customersCityRep.Create(customersCity);
        }
        private void UserAddingProcess()
        {
            Console.Write("Введите логин: ");
            string login = Console.ReadLine();
            Console.Write("Введите пароль: ");
            string password = Console.ReadLine();
            Console.Write("Введите почту: ");
            string email = Console.ReadLine();
            Console.Write("Введите номер телефона: ");
            string phoneNumber = Console.ReadLine();
            User user = new User
            {
                Id = 0,
                Login = login,
                Password = password,
                Email = email,
                PhoneNumber = phoneNumber
            };
            _userRep.Create(user);
        }
        private void AddingProcessing()
        {
            Console.Clear();
            int ans = AddingOptions();
            Console.Clear();
            switch (ans)
            {
                case 1:
                {
                    CityAddingProcess();
                    break;
                }
                case 2:
                {
                    CustomerAddingProcess();
                    break;
                }
                case 3:
                {
                    CustomersCityAddingProcess();
                    break;
                }
                case 4:
                {
                    UserAddingProcess();
                    break;
                }
            }
        }
        private void SaveChangesProcessing()
        {
            _cityRep.Save();
            _customerRep.Save();
            _customersCityRep.Save();
            _userRep.Save();
        }
    }
}