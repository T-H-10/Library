using library.Entities;
using Microsoft.AspNetCore.Mvc;

namespace library.Services
{
    public class BookService
    {

        public List<Book> GetBooks() => DataContext.Books;
        public Book GetBook(int code) => 
            DataContext.Books.Find(book => book.Code == code);
        public bool AddBook([FromBody] Book book)
        {
            if (book == null) return false;
            DataContext.Books.Add(book);
            return true;
        }
        public bool UpdateBook(int code, [FromBody] Book book)
        {
            if (book == null) return false;
            for (int i = 0; i < DataContext.Books.Count; i++)
            {
                if (DataContext.Books[i].Code == code)
                {
                    DataContext.Books[i].Author = book.Author;
                    DataContext.Books[i].Name = book.Name;
                    DataContext.Books[i].DepartmentCode = book.DepartmentCode;
                    DataContext.Books[i].ColumnNum = book.ColumnNum;
                    DataContext.Books[i].ShelfNum = book.ShelfNum;
                    DataContext.Books[i].Pages = book.Pages;
                    DataContext.Books[i].Copies = book.Copies;
                    DataContext.Books[i].CopyNum = book.CopyNum;
                    DataContext.Books[i].Status = book.Status;
                    DataContext.Books[i].DaysToBorrow = book.DaysToBorrow;
                    DataContext.Books[i].BuyingDate = book.BuyingDate;
                    return true;
                }
            }
            return false;
        }
        public bool DeleteBook(int code) => DataContext.Books.Remove(GetBook(code));
        //{
        //    for (int i = 0; i < DataContext.Books.Count; i++)
        //    {
        //        if (DataContext.Books[i].Code == code)
        //        {
        //            DataContext.Books.RemoveAt(i);
        //            return true;
        //        }
        //    }
        //    return false;
        //}
    }
}
