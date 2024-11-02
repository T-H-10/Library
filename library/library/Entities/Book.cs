namespace library.Entities
{
    public enum BookStatus
    {
        borrowed = 1, available = 2, unavailable = 4
    }
    public class Book
    {
        public int Code { get; set; }
        public string Author { get; set; }
        public string Name { get; set; }
        public int DepartmentCode { get; set; }
        public int ColumnNum { get; set; }
        public int ShelfNum { get; set; }
        public int Pages { get; set; }
        public int Copies { get; set; }
        public int CopyNum { get; set; }
        public BookStatus Status { get; set; }
        public int DaysToBorrow { get; set; }
        public DateOnly BuyingDate { get; set; }
    }
}
