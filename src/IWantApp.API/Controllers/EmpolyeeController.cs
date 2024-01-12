using IWantApp.Application.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IWantApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpolyeeController : ControllerBase
    {
        // GET: api/<EmpolyeesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {  
            return new string[] { "value1", "value2" };
        }

        // GET api/<EmpolyeesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmpolyeesController>
        [HttpPost]
        public void Post([FromBody] EmployeeDTO employee)
        {



        }

        // PUT api/<EmpolyeesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmpolyeesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
