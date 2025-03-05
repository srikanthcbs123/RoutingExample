using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RoutingExample.Controllers
{
    [Route("api/[controller]")]//parent route declare here
    [ApiController]//attributes.
    public class EmployeesController : ControllerBase
    {


        [HttpGet]//api methods
        [Route("GetEmployee/{sipId}/{siphealthcheckId}")]//children routename define here.

        public async Task<IActionResult> EmployeeDetails([FromRoute] string sipId, [FromRoute] string siphealthcheckId)
        {
            var result = sipId + siphealthcheckId;
            //In future we can create some reporsitroty classes we can return database data
            return Ok(result);
        }

        [HttpGet]//api methods
        [Route("GetEmployee/{sipId}/{siphealthcheckId}/{a}/{b}/{c}")]//children routename define here.

        public async Task<IActionResult> EmployeeDetails([FromRoute] string sipId, [FromRoute] string siphealthcheckId,[FromRoute] string a, [FromRoute] string b, [FromRoute] string c)
     
        {
            var result = sipId + siphealthcheckId+a+b+c;
            //In future we can create some reporsitroty classes we can return database data
            return Ok(result);
        }

        private string GetName()
        {
            return "hello";
        }
    }
}
