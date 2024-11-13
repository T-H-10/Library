using library.Entities;
using Microsoft.AspNetCore.Mvc;

namespace library.Services
{
    public class BookService
    {
        readonly IDataContext _dataContext;
        public BookService(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<Book> GetBooks() => _dataContext.LoadBooks();
        public Book GetBook(int code)
        {
            List<Book> books = _dataContext.LoadBooks();
            if (books == null) return null;
            return books.Find(book => book.Code == code);
        }
        public bool AddBook([FromBody] Book book)
        {
            List<Book> books = _dataContext.LoadBooks();
            if (book == null) return false;
            books.Add(book);
            return _dataContext.SaveBooks(books);
        }
        public bool UpdateBook(int code, [FromBody] Book book)
        {
            List<Book> books = _dataContext.LoadBooks();
            if (book == null || books==null) return false;
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Code == code)
                {
                    books[i].Author = book.Author;
                    books[i].Name = book.Name;
                    books[i].DepartmentCode = book.DepartmentCode;
                    books[i].ColumnNum = book.ColumnNum;
                    books[i].ShelfNum = book.ShelfNum;
                    books[i].Pages = book.Pages;
                    books[i].Copies = book.Copies;
                    books[i].CopyNum = book.CopyNum;
                    books[i].Status = book.Status;
                    books[i].DaysToBorrow = book.DaysToBorrow;
                    books[i].BuyingDate = book.BuyingDate;
                    return _dataContext.SaveBooks(books);
                }
            }
            return false;
        }
        public bool DeleteBook(int code) //=> DataContext.Books.Remove(GetBook(code));
        {
            List<Book> books = _dataContext.LoadBooks();
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Code == code)
                {
                    books.RemoveAt(i);
                    return _dataContext.SaveBooks(books);
                }
            }
            return false;
        }
    }
}
