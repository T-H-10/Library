using library.Entities;
using library.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LendingsController : ControllerBase
    {
        readonly LendingService _lendingService= new LendingService(new DataContext());
        // GET: api/<LendingsController>
        [HttpGet]
        public ActionResult<List<Lending>> Get()
        {
            List<Lending> result = _lendingService.GetLendings();
            if(result == null) { return NotFound(); }
            return result;
        }

        // GET api/<LendingsController>/5
        [HttpGet("{id}")]
        public ActionResult<Lending> Get(int code)
        {
            Lending result=_lendingService.GetLending(code);
            if(result == null) { return NotFound(); };
            return result;
        }

        // POST api/<LendingsController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] Lending lending)
        {
            return _lendingService.AddLending(lending);
        }

        // PUT api/<LendingsController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int code, [FromBody] Lending lending)
        {
            return _lendingService.UpdateLending(code, lending);
        }

        // DELETE api/<LendingsController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int code)
        {
            return _lendingService.DeleteLending(code);
        }
    }
}
