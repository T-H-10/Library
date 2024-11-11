using library.Entities;
using library.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        readonly MemberService _memberService = new MemberService();
        public MembersController()
        {
            _memberService = new MemberService();
        }
        // GET: api/<MembersController>
        [HttpGet]
        public ActionResult<List<Member>> Get()
        {
            List<Member> members = _memberService.GetMembers();
            if (members == null) { return NotFound(); }
            return members;
        }

        // GET api/<MembersController>/5
        [HttpGet("{id}")]
        public ActionResult<Member> GetById(string id)
        {
            if (id == null) { return NotFound(); }
            Member result = _memberService.GetMemberById(id);
            if (result == null) { return NotFound(); }
            return result;
        }

        // POST api/<MembersController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] Member member)
        {
            return _memberService.AddMember(member);
        }
        // PUT api/<MembersController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int code, [FromBody] Member member)
        {
            return _memberService.UpdateMember(code, member);
        }
        // DELETE api/<MembersController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int code)
        {
            return _memberService.DeleteMember(code);
        }
    }
}
