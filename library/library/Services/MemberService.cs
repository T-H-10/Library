using library.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;

namespace library.Services
{
    public class MemberService
    {
        public List<Member> GetMembers() => DataContext.Members;
        public Member GetMemberById(string id) =>
            DataContext.Members.Find(member => member.Id == id);
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
            if (member == null)
                return false;
            DataContext.Members.Add(member);
            return true;
        }
        public bool UpdateMember(int code, [FromBody] Member member)
        {
            //if (code == null) { return false; }
            if (member == null) { return false; }
            for (int i = 0; i < DataContext.Members.Count; i++)
            {
                if (DataContext.Members[i].Code == code)
                {
                    //DataContext.Members[i].Code = member.Code;
                    DataContext.Members[i].Name = member.Name;
                    DataContext.Members[i].Id = member.Id;
                    DataContext.Members[i].City = member.City;
                    DataContext.Members[i].Address = member.Address;
                    DataContext.Members[i].Tel = member.Tel;
                    DataContext.Members[i].Children = member.Children;
                    DataContext.Members[i].Status = member.Status;
                    DataContext.Members[i].JoiningDate = member.JoiningDate;
                    return true;
                }
            }
            return false;
        }
        public bool DeleteMember(int code)
        //DataContext.Members.Remove(GetMemberById(id));
        {
            //if (code == null) { return false; }
            for (int i = 0; i < DataContext.Members.Count; i++)
            {
                if (DataContext.Members[i].Code == code)
                {
                    DataContext.Members.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
    }
}
