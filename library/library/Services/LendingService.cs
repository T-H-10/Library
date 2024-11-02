using library.Entities;
using Microsoft.AspNetCore.Mvc;

namespace library.Services
{
    public class LendingService
    {
        private List<Lending> lendings = new List<Lending>() {
            new Lending()
            {
                Code=10,
                Book=1000,
                Member=101,
                LendingDate=new DateTime(2024,11,02)
            },
            new Lending()
            {
                Code=11,
                Book=1001,
                Member=101,
                LendingDate=new DateTime(2024,11,02)
            }
        };

        public List<Lending> GetLendings()
        {
            return lendings;
        }
        public Lending GetLending(int code)
        {
            foreach (var lending in lendings)
            {
                if (lending.Code == code)
                    return lending;
            }
            return null;
        }
        public bool PostLending([FromBody] Lending lending)
        {
            if (lending == null) return false;
            lendings.Add(lending);
            return true;
        }
        public bool PutLending(int code, [FromBody] Lending lending)
        {
            if (lending == null) { return false; }
            for (int i = 0; i < lendings.Count; i++)
            {
                if (lendings[i].Code == code)
                {
                    lendings[i] = lending;
                    return true;
                }
            }
            return false;
        }
        public bool DeleteLending(int code)
        {
            for (int i = 0; i < lendings.Count; i++)
            {
                if (lendings[i].Code == code)
                {
                    lendings.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
    }
}
