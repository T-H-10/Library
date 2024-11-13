using System.Text.Json;

namespace library.Entities
{
    public class DataContext : IDataContext
    {
        //    public static List<Book> Books = new List<Book>(){
        //        new Book(){
        //            //Code=1000,
        //            Author="yona sapir",
        //            Name="mitchaze",
        //            DepartmentCode=3,
        //            ColumnNum=3,
        //            ShelfNum=1,
        //            Pages=460,
        //            Copies=4,
        //            CopyNum=2,
        //            Status=BookStatus.available,
        //            DaysToBorrow=14,
        //            BuyingDate=new DateTime(2024,02,23)
        //        },
        //        new Book(){
        //            //Code=1001,
        //            Author="yona sapir",
        //            Name="mitchaze",
        //            DepartmentCode=3,
        //            ColumnNum=3,
        //            ShelfNum=1,
        //            Pages=460,
        //            Copies=4,
        //            CopyNum=3,
        //            Status=BookStatus.available,
        //            DaysToBorrow=14,
        //            BuyingDate=new DateTime(2024,02,23)
        //        }
        //    };
        //    public static List<Department> Departments = new List<Department>(){
        //        new Department()
        //    {
        //        Description = "מתח",
        //            Name = "מתח",
        //            Age = 16
        //        },
        //        new Department()
        //    {
        //        Description = "ספרים ראשונים לילד",
        //            Name = "תינוקים",
        //            Age = 1
        //        }
        //};
        //    public static List<Lending> Lendings = new List<Lending>() {
        //        new Lending()
        //        {
        //            //Code=10,
        //            Book=1000,
        //            Member=101,
        //            LendingDate=new DateTime(2024,11,02)
        //        },
        //        new Lending()
        //        {
        //            //Code=11,
        //            Book=1001,
        //            Member=101,
        //            LendingDate=new DateTime(2024,11,02)
        //        }
        //    };
        //    public static List<Member> Members;
        //        //new List<Member>() {
        //        //new Member() {
        //        //        //Code = 100,
        //        //        Name = "moshe",
        //        //        Id = "123456789",
        //        //        City = "P.T.",
        //        //        Address = "Rozovski 1",
        //        //        Children = 5,
        //        //        Tel = "03-9336497",
        //        //        Status=Statuses.active,
        //        //        JoiningDate = new DateTime(2024, 10, 30)
        //        //        },new Member()
        //        //        {
        //        //        //Code = 101,
        //        //        Name = "aharon",
        //        //        Id = "123456798",
        //        //        City = "P.T.",
        //        //        Address = "Rozovski 10",
        //        //        Children = 3,
        //        //        Tel = "03-9335197",
        //        //        Status=Statuses.active,
        //        //        JoiningDate = new DateTime(2024, 10, 31)
        //        //        },new Member()
        //        //        {
        //        //        //Code = 102,
        //        //        Name = "levi",
        //        //        Id = "123546798",
        //        //        City = "P.T.",
        //        //        Address = "Meshorer 3",
        //        //        Children = 2,
        //        //        Tel = "03-9093297",
        //        //        Status=Statuses.active,
        //        //        JoiningDate = new DateTime(2024, 10, 31)
        //        //        }
        //        //};
        //    public static List<Order> Orders = new List<Order>();
        public List<Member> LoadMembers()
        {
            Member.code = 100;
            string path = Path.Combine(AppContext.BaseDirectory, "Data", "membersData.json");
            string membersJson = File.ReadAllText(path);
            var members = JsonSerializer.Deserialize<List<Member>>(membersJson);
            return members;
        }
        public bool SaveMembers(List<Member> members)
        {
            try
            {
                string path = Path.Combine(AppContext.BaseDirectory, "Data", "membersData.json");
                string jsonMembers = JsonSerializer.Serialize(members);
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                File.WriteAllText(path, jsonMembers);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<Book> LoadBooks()
        {
            string path = Path.Combine(AppContext.BaseDirectory, "Data", "booksData.json");
            string jsonBooks = File.ReadAllText(path);
            var books = JsonSerializer.Deserialize<List<Book>>(jsonBooks);
            return books;
        }
        public bool SaveBooks(List<Book> books)
        {
            try
            {
                string path = Path.Combine(AppContext.BaseDirectory, "Data", "booksData.json");
                string jsonBooks = JsonSerializer.Serialize(books);
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                File.WriteAllText(path, jsonBooks);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<Department> LoadDepartments()
        {
            string path = Path.Combine(AppContext.BaseDirectory, "Data", "departmentsData.json");
            string jsonDepartments = File.ReadAllText(path);
            List<Department> departments = JsonSerializer.Deserialize<List<Department>>(jsonDepartments);
            return departments;
        }
        public bool SaveDepartments(List<Department> departments)
        {
            try
            {
                string path = Path.Combine(AppContext.BaseDirectory, "Data", "departmentsData.json");
                string jsonDepartments = JsonSerializer.Serialize(departments);
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                File.WriteAllText(path, jsonDepartments);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<Lending> LoadLendings()
        {
            string path = Path.Combine(AppContext.BaseDirectory, "Data", "lendingsData.json");
            string jsonLendings = File.ReadAllText(path);
            List<Lending> lendings = JsonSerializer.Deserialize<List<Lending>>(jsonLendings);
            return lendings;
        }
        public bool SaveLendings(List<Lending> lendings)
        {
            try
            {
                string path = Path.Combine(AppContext.BaseDirectory, "Data", "lendingsData.json");
                string jsonLendings = JsonSerializer.Serialize(lendings);
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                File.WriteAllText(path, jsonLendings);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<Order> LoadOrders()
        {
            string path = Path.Combine(AppContext.BaseDirectory, "Data", "ordersData.json");
            string jsonOrders = File.ReadAllText(path);
            List<Order> orders = JsonSerializer.Deserialize<List<Order>>(jsonOrders);
            return orders;
        }
        public bool SaveOrders(List<Order> orders)
        {
            try
            {
                string path = Path.Combine(AppContext.BaseDirectory, "Data", "ordersData.json");
                string jsonOrders = JsonSerializer.Serialize(orders);
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                File.WriteAllText(path, jsonOrders);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

}
