using library.Entities;
using Microsoft.AspNetCore.Mvc;

namespace library.Services
{
    public class LendingService
    {
        readonly IDataContext _dataContext;
        public LendingService(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<Lending> GetLendings() => _dataContext.LoadLendings();
        public Lending GetLending(int code)
        {
            List<Lending> lendings = _dataContext.LoadLendings();
            if(lendings == null) { return null; }
            return lendings.Find(lending => lending.Code == code);
        }
            
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
            List<Lending> lendings = _dataContext.LoadLendings();
            lendings.Add(lending);
            return _dataContext.SaveLendings(lendings);
        }
        public bool UpdateLending(int code, [FromBody] Lending lending)
        {
            if (lending == null) { return false; }
            List<Lending> lendings = _dataContext.LoadLendings();
            for (int i = 0; i < lendings.Count; i++)
            {
                if (lendings[i].Code == code)
                {
                    lendings[i].Book = lending.Book;
                    lendings[i].Member = lending.Member;
                    lendings[i].LendingDate = lending.LendingDate;
                    lendings[i].ReturningDate = lending.ReturningDate;
                    return _dataContext.SaveLendings(lendings);
                }
            }
            return false;
        }
        public bool DeleteLending(int code)
        //DataContext.Lendings.Remove(GetLending(code));
        {
            List<Lending> lendings = _dataContext.LoadLendings();
            for (int i = 0; i < lendings.Count; i++)
            {
                if (lendings[i].Code == code)
                {
                    lendings.RemoveAt(i);
                    return _dataContext.SaveLendings(lendings);
                }
            }
            return false;
        }
    }
}
