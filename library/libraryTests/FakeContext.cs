using library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libraryTests
{
    public class FakeContext : IDataContext
    {
        public List<Member> LoadMembers()
        {
            List<Member> members = new List<Member>()
            {
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
                 },
                new Member()
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
                 },
                new Member()
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
            return members;
        }
        public bool SaveMembers(List<Member> members)
        {
            return true;
        }
        public List<Book> LoadBooks()
        {
            return null;
        }
        public bool SaveBooks(List<Book> books)
        {
            return true;
        }
        public List<Department> LoadDepartments()
        {
            return null;
        }
        public bool SaveDepartments(List<Department> departments)
        {
            return true;
        }
        public List<Lending> LoadLendings()
        {
            return null;
        }
        public bool SaveLendings(List<Lending> lendings)
        {
            return true;
        }
        public List<Order> LoadOrders()
        {
            return null;
        }
        public bool SaveOrders(List<Order> orders)
        {
            return true;
        }

    }
}
