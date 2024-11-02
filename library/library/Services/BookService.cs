using library.Entities;
using Microsoft.AspNetCore.Mvc;

namespace library.Services
{
    public class BookService
    {
        private List<Book> books = new List<Book>(){
            new Book(){
                Code=1000,
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
                BuyingDate=new DateOnly(2024,02,23)
            },
            new Book(){
                Code=1001,
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
                BuyingDate=new DateOnly(2024,02,23)
            }
        };
        public List<Book> GetBooks()
        {
            return books;
        }
        public Book GetBook(int code)
        {
            foreach (Book book in books)
            {
                if (book.Code == code) return book;
            }
            return null;
        }
        public bool PostBook([FromBody] Book book)
        {
            if (book == null) return false;
            books.Add(book);
            return true;
        }
        public bool PutBook(int code, [FromBody] Book book)
        {
            if (book == null) return false;
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Code == code)
                {
                    books[i] = book;
                    return true;
                }
            }
            return false;
        }
        public bool DeleteBook(int code)
        {
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Code == code)
                {
                    books.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
    }
}
