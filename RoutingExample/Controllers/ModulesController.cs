using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RoutingExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModulesController : ControllerBase
    {
        [HttpGet]//get api method
        [Route("Getstringdata")]//child routes define here
        public string listofdata()
        {
            var result = "It Department";
            return result;
        }
        [HttpPost]//post api method
        [Route("insertdata")]//child routes define here
        public int insertdata(int a, int b)
        {
            return a + b;
        }
        [HttpPut]//update api method
        [Route("update data")]//child routes define here
        public int updatedata(int a, int b)
        {
            return a - b;
        }
        [HttpDelete]//delete api method 
        [Route("deletedata")]//child routes define here
        public int deletedata(int a, int b)
        {
            return a - b;

        }
    }
}
