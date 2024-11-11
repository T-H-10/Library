using library.Entities;
using Microsoft.AspNetCore.Mvc;

namespace library.Services
{
    public class LendingService
    {

        public List<Lending> GetLendings() => DataContext.Lendings;
        public Lending GetLending(int code) =>
            DataContext.Lendings.Find(lending => lending.Code == code);
        //{
        //    foreach (var lending in DataContext.Lendings)
        //    {
        //        if (lending.Code == code)
        //            return lending;
        //    }
        //    return null;
        //}
        public bool AddLending([FromBody] Lending lending)
        {
            if (lending == null) return false;
            DataContext.Lendings.Add(lending);
            return true;
        }
        public bool UpdateLending(int code, [FromBody] Lending lending)
        {
            if (lending == null) { return false; }
            for (int i = 0; i < DataContext.Lendings.Count; i++)
            {
                if (DataContext.Lendings[i].Code == code)
                {
                    DataContext.Lendings[i].Book = lending.Book;
                    DataContext.Lendings[i].Member = lending.Member;
                    DataContext.Lendings[i].LendingDate = lending.LendingDate;
                    DataContext.Lendings[i].ReturningDate = lending.ReturningDate;
                    return true;
                }
            }
            return false;
        }
        public bool DeleteLending(int code) =>
            DataContext.Lendings.Remove(GetLending(code));
        //{
        //    for (int i = 0; i < DataContext.Lendings.Count; i++)
        //    {
        //        if (DataContext.Lendings[i].Code == code)
        //        {
        //            DataContext.Lendings.RemoveAt(i);
        //            return true;
        //        }
        //    }
        //    return false;
        //}
    }
}
