using library.Entities;
using library.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        readonly DepartmentService _departmentService=new DepartmentService();
        // GET: api/<DepartmentsController>
        [HttpGet]
        public ActionResult<List<Department>> Get()
        {
            List<Department> result=_departmentService.GetDepartments();
            if(result == null) { return NoContent(); }//---
            return Ok(result);
        }

        // GET api/<DepartmentsController>/5
        [HttpGet("{id}")]
        public ActionResult<Department> Get(int code)
        {
            Department result= _departmentService.GetDepartment(code);
            if (result == null) { return NotFound(); }
            return Ok(result);
        }

        // POST api/<DepartmentsController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] Department department)
        {
            return _departmentService.PostDepartment(department);
        }

        // PUT api/<DepartmentsController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int code, [FromBody] Department department)
        {
            return _departmentService.PutDepartment(code, department);
        }

        // DELETE api/<DepartmentsController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int code)
        {
            return _departmentService.DeleteDepartment(code);
        }
    }
}
