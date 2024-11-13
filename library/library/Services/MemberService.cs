using library.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;

namespace library.Services
{
    public class MemberService
    {
        readonly IDataContext _dataContext;
        public MemberService(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<Member> GetMembers() => _dataContext.LoadMembers();
        public Member GetMemberById(string id)
        {
            List<Member> members = _dataContext.LoadMembers();
            if (members == null) return null;
            return members.Find(member => member.Id == id);
        }
        //{
        //    foreach (var member in DataContext.Members)
        //    {
        //        if (member.Id == id)
        //            return member;
        //    }
        //    return null;//--------------
        //}
        public bool AddMember([FromBody] Member member)
        {
            if (member == null) return false;
            List<Member> members = _dataContext.LoadMembers();
            members.Add(member);
            return _dataContext.SaveMembers(members);
        }
        public bool UpdateMember(int code, [FromBody] Member member)
        {
            if (member == null) { return false; }
            List<Member> members = _dataContext.LoadMembers();
            for (int i = 0; i < members.Count; i++)
            {
                if (members[i].Code == code)
                {
                    //DataContext.Members[i].Code = member.Code;
                    members[i].Name = member.Name;
                    members[i].Id = member.Id;
                    members[i].City = member.City;
                    members[i].Address = member.Address;
                    members[i].Tel = member.Tel;
                    members[i].Children = member.Children;
                    members[i].Status = member.Status;
                    members[i].JoiningDate = member.JoiningDate;
                    return _dataContext.SaveMembers(members);
                }
            }
            return false;
        }
        public bool DeleteMember(string id)
        //DataContext.Members.Remove(GetMemberById(id));
        {
            if (id == null) { return false; }
            List<Member> members = _dataContext.LoadMembers();
            for (int i = 0; i < members.Count; i++)
            {
                if (members[i].Id == id)
                {
                    members.RemoveAt(i);
                    return _dataContext.SaveMembers(members);
                }
            }
            return false;
        }
    }
}
