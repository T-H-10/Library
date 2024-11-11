using library.Controllers;
using library.Entities;
using library.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace libraryTests
{
    public class MemberControllerTests
    {
        [Fact]
        public void GetAll_returnsOK()
        {
            var memberController = new MembersController();
            var result = memberController.Get();
            Assert.IsType<ActionResult<List<Member>>>(result);
        }
        [Fact]
        public void GetById_returnsMember()
        {
            var id = "123456789";
            var memberController = new MembersController();
            var result = memberController.GetById(id).Value;
            Assert.IsType<Member>(result);
        }
        [Fact]
        public void GetById_returnsNull()
        {
            var id = "111111222";
            var memberController = new MembersController();
            var result = memberController.GetById(id).Value;
            Assert.Null(result);
        }
        [Fact]
        public void Post_returnsTrue()
        {
            Member member = new Member();
            var memberController = new MembersController();
            var result = memberController.Post(member).Value;
            Assert.True(result);
        }

        [Fact]
        public void Post_returnsFalse()
        {
            Member member = null;
            var memberController = new MembersController();
            var result = memberController.Post(member).Value;
            Assert.False(result);
        }

        [Fact]
        public void Put_returnsTrue()
        {
            Member member = DataContext.Members.First();
            var memberController = new MembersController();
            var result = memberController.Put(member.Code, member).Value;
            Assert.True(result);
        }
        [Fact]
        public void Put_returnsFalse_EmptyObject()
        {
            Member member = null;
            var memberController = new MembersController();
            var result = memberController.Put(100, member).Value;
            Assert.False(result);
        }
        [Fact]
        public void Put_returnsFalse_NotCodeToUpdate()
        {
            Member member = new Member();
            var memberController = new MembersController();
            var result = memberController.Put(10, member).Value;
            Assert.False(result);
        }

        [Fact]
        public void Delete_returnsTrue()
        {
            Member member = DataContext.Members.First();
            var memberController = new MembersController();
            var result = memberController.Delete(member.Code).Value;
            Assert.True(result);
        }
        [Fact]
        public void Delete_returnsFalse_NotFoundCode()
        {
            int code = 10;
            var memberController = new MembersController();
            var result = memberController.Delete(code).Value;
            Assert.False(result);
        }
        
        //service
        //[Fact]
        //public void GetById_returnsMember()
        //{
        //    var id = "123456789";
        //    var _memberService = new MemberService();
        //    var result = _memberService.GetMemberById(id);
        //    Assert.IsType<Member>(result);
        //}
        //[Fact]
        //public void GetById_returnsNull()
        //{
        //    var id = "111111222";
        //    var _memberService = new MemberService();
        //    var result = _memberService.GetMemberById(id);
        //    Assert.Null(result);
        //}
        //[Fact]
        //public void AddMember_returnsTrue()
        //{
        //    Member member = new Member();
        //    var _memberService = new MemberService();
        //    var result = _memberService.AddMember(member);
        //    Assert.True(result);
        //}

        //[Fact]
        //public void AddMember_returnsFalse()
        //{
        //    Member member = null;
        //    var _memberService = new MemberService();
        //    var result = _memberService.AddMember(member);
        //    Assert.False(result);
        //}
    }
}
