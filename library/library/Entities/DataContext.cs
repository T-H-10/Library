namespace library.Entities
{
    public static class DataContext
    {
        //public static List<Book> Books { get; set; }
        //public static List<Department> Departments { get; set; }
        //public static List<Lending> Lendings { get; set; }
        //public static List<Member> Members { get; set; }
        //public static List<Order> Orders { get; set; }
        //public DataContext()
        //{
        public static List<Book> Books = new List<Book>(){
            new Book(){
                //Code=1000,
                Author="yona sapir",
                Name="mitchaze",
                DepartmentCode=3,
                ColumnNum=3,
                ShelfNum=1,
                Pages=460,
                Copies=4,
                CopyNum=2,
                Status=BookStatus.available,
                DaysToBorrow=14,
                BuyingDate=new DateTime(2024,02,23)
            },
            new Book(){
                //Code=1001,
                Author="yona sapir",
                Name="mitchaze",
                DepartmentCode=3,
                ColumnNum=3,
                ShelfNum=1,
                Pages=460,
                Copies=4,
                CopyNum=3,
                Status=BookStatus.available,
                DaysToBorrow=14,
                BuyingDate=new DateTime(2024,02,23)
            }
        };
        public static List<Department> Departments = new List<Department>(){
            new Department()
        {
            Description = "מתח",
                Name = "מתח",
                Age = 16
            },
            new Department()
        {
            Description = "ספרים ראשונים לילד",
                Name = "תינוקים",
                Age = 1
            }
    };
        public static List<Lending> Lendings = new List<Lending>() {
            new Lending()
            {
                //Code=10,
                Book=1000,
                Member=101,
                LendingDate=new DateTime(2024,11,02)
            },
            new Lending()
            {
                //Code=11,
                Book=1001,
                Member=101,
                LendingDate=new DateTime(2024,11,02)
            }
        };
        public static List<Member> Members = new List<Member>() {
            new Member() {
                    //Code = 100,
                    Name = "moshe",
                    Id = "123456789",
                    City = "P.T.",
                    Address = "Rozovski 1",
                    Children = 5,
                    Tel = "03-9336497",
                    Status=Statuses.active,
                    JoiningDate = new DateTime(2024, 10, 30)
                    },new Member()
                    {
                    //Code = 101,
                    Name = "aharon",
                    Id = "123456798",
                    City = "P.T.",
                    Address = "Rozovski 10",
                    Children = 3,
                    Tel = "03-9335197",
                    Status=Statuses.active,
                    JoiningDate = new DateTime(2024, 10, 31)
                    },new Member()
                    {
                    //Code = 102,
                    Name = "levi",
                    Id = "123546798",
                    City = "P.T.",
                    Address = "Meshorer 3",
                    Children = 2,
                    Tel = "03-9093297",
                    Status=Statuses.active,
                    JoiningDate = new DateTime(2024, 10, 31)
                    }
            };
        public static List<Order> Orders = new List<Order>();
        //}
    }
}
