using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoutingExample.Models;

namespace RoutingExample.Controllers
{
    [Route("api/[controller]")]//parent route declare here
    [ApiController]//attributes.
    public class EmployeesController : ControllerBase
    {

    
        //[HttpGet]//api methods
       // [Route("GetEmployee/{sipId}/{siphealthcheckId}")]//children routename define here.
        [HttpGet("GetEmployee/{sipId}/{siphealthcheckId}")]//his is the shortcut way of writting httpmethod and route in single line
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


        [HttpGet("GetEmployeesQueryString")]
        public string GetData([FromQuery] string a, [FromQuery] string b, [FromQuery] string c, [FromQuery] string d, [FromQuery] string e)
        {
            return a + b + c + d + e;

        }
        [HttpGet("GetEmployeesSinleQueryString")]//sychronus programming methods
        public string GetDatawithsqingleparam([FromQuery] string a)
        {
            return a;

        }
        [HttpGet("Sip-comment/{SiphealthCheckDetailId}")]//asynchronous programming methods.
        public async Task<IActionResult> SipComment([FromRoute] long SiphealthCheckDetailId)
        {
            var checkType = SiphealthCheckDetailId;
            return Ok(checkType);
        }
        [HttpGet("SipEngagementSelection/healthCheckDetailId/{healthCheckDetailId}/questionId/{questionId}")]
        public async Task<IActionResult> SipGet([FromRoute] int healthCheckDetailId, [FromRoute] int questionId)
        {

            return Ok(healthCheckDetailId  + questionId);

        }


        //Querystring means route starts with ?(question mark firsttimeonly)
        // Route: GET /api/RealtimeRoutes/search?name=Phone&category=Electronics
        [HttpGet("SearchProducts1")]
        public IActionResult SearchProducts1([FromQuery] string name, [FromQuery] string category)
        {
            var result = "Searching for" + name + "in" + category + "category.";
            //the below one is the string concadination
            return Ok($"Searching for {name} in {category} category.");
        }
        // Route: GET /api/RealtimeRoutes/SearchProducts2?name=Phone
        [HttpGet("SearchProducts2")]
        public IActionResult SearchProducts2([FromQuery] string name)
        {
            //the below one is the string concadination
            return Ok($"Searching for {name}.");
        }
        //Example: Combining [FromRoute] and [FromQuery]
        // Route: http://localhost:5228/api/RealtimeRoutes/123?status=pen
        [HttpGet("{orderId:int}")]
        public IActionResult GetOrderDetails(
            [FromRoute] int orderId,
            [FromQuery] string status)
        {
            return Ok($"Order ID: {orderId}, Status: {status}");
        }

        //Complex binding with [FromQuery]
        // Route: http://localhost:5228/api/RealtimeRoutes/filter?Name=hyd&Category=book&MinPrice=10&MaxPrice=20
        [HttpGet("filter")]
        public IActionResult FilterProducts([FromQuery] ProductFilter filter)
        {
            return Ok($"Filtering {filter.Name} with min price {filter.MinPrice}.");
        }






        private string GetName()
        {
            return "hello";
        }
    }
}
