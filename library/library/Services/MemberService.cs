using library.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace library.Services
{
    public class MemberService
    {
        private List<Member> members = new List<Member>() {
            new Member() {
                    Code = 100,
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
                    Code = 101,
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
                    Code = 102,
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
        public List<Member> GetMembers()
        {
            return members;
        }
        public Member GetMember(string id)
        {
            foreach (var member in members)
            {
                if (member.Id == id)
                    return member;
            }
            return null;//--------------
        }
        public bool PostMember([FromBody] Member member)
        {
            if (member == null)
                return false;
            members.Add(member);
            return true;
        }
        public bool PutMember(string id, [FromBody] Member member)
        {
            if (id == null) { return false; }
            if(member==null) { return false; }
            for (int i = 0; i < members.Count; i++)
            {
                if (members[i].Id == id)
                {
                    members[i] = member;
                    return true;
                }
            }
            return false;
        }
        public bool DeleteMember(string id)
        {
            if(id == null) { return false; }
            for (int i = 0; i < members.Count; i++)
            {
                if (members[i].Id == id)
                {
                    members.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
    }
}
