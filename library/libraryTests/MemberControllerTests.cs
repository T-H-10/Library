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
            var memberController = new MembersController(new MemberService(new FakeContext()));
            var result = memberController.Get();
            Assert.IsType<ActionResult<List<Member>>>(result);
        }
        [Fact]
        public void GetById_returnsMember()
        {
            var id = "123456789";
            var memberController = new MembersController(new MemberService(new FakeContext()));
            var result = memberController.GetById(id);
            Assert.IsType<Member>(result.Value);
        }
        [Fact]
        public void GetById_returnsNull()
        {
            var id = "111111222";
            var memberController = new MembersController(new MemberService(new FakeContext()));
            var result = memberController.GetById(id);
            Assert.Null(result.Value);
        }
        [Fact]
        public void Post_returnsTrue()
        {
            Member member = new Member();
            var memberController = new MembersController(new MemberService(new FakeContext()));
            var result = memberController.Post(member);
            Assert.True(result.Value);
        }

        [Fact]
        public void Post_returnsFalse()
        {
            Member member = null;
            var memberController = new MembersController(new MemberService(new FakeContext()));
            var result = memberController.Post(member);
            Assert.False(result.Value);
        }

        [Fact]
        public void Put_returnsTrue()
        {
            var member = new Member()
            {
                Id = "125",
                Name = "dsa",
                Address = "sdnkf",
                Children = 3,
                Tel = "123",
                Status = Statuses.active,
                City = "ghf"
            };
            var code = 100;
            var memberController = new MembersController(new MemberService(new FakeContext()));
            var result = memberController.Put(code, member);
            Assert.True(result.Value);
        }
        [Fact]
        public void Put_returnsFalse_EmptyObject()
        {
            Member member = null;
            var memberController = new MembersController(new MemberService(new FakeContext()));
            var result = memberController.Put(100, member);
            Assert.False(result.Value);
        }
        [Fact]
        public void Put_returnsFalse_NotCodeToUpdate()
        {
            Member member = new Member();
            var memberController = new MembersController(new MemberService(new FakeContext()));
            var result = memberController.Put(10, member);
            Assert.False(result.Value);
        }

        [Fact]
        public void Delete_returnsTrue()
        {
            string id = "123456789";
            var memberController = new MembersController(new MemberService(new FakeContext()));
            var result = memberController.Delete(id);
            Assert.True(result.Value);
        }
        [Fact]
        public void Delete_returnsFalse_NotFoundCode()
        {
            string id = "123";
            var memberController = new MembersController(new MemberService(new FakeContext()));
            var result = memberController.Delete(id);
            Assert.False(result.Value);
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
