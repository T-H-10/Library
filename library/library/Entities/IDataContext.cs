namespace library.Entities
{
    public interface IDataContext
    {
        public List<Book> LoadBooks();
        public bool SaveBooks(List<Book> books);
        public List<Department> LoadDepartments();
        public bool SaveDepartments(List<Department> departments);
        public List<Lending> LoadLendings();
        public bool SaveLendings(List<Lending> lendings);
        public List<Member> LoadMembers();
        public bool SaveMembers(List<Member> members);
        public List<Order> LoadOrders();
        public bool SaveOrders(List<Order> orders);
    }
}
