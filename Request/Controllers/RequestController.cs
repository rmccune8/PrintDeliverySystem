using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Request.Model;
using Request.Service;

namespace Request.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestService _requestService;
        public RequestController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        //// GET api/values
        //[HttpGet]
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public ActionResult<string> Get(int id)
        //{
        //    return "value";
        //}

        // TODO: security handled via attribute
        [HttpPost]
        public async Task<IActionResult> PrintSeasonTickets([FromBody] SeasonTicketRequest seasonTicketRequest)
        {
            await _requestService.ProcessSeasonTicketRequestAsync(seasonTicketRequest.ClientId, seasonTicketRequest.Year);
            // if an error occurs in ProcessSeasonTicketRequestAsync, it will throw an exception and middleware will change the HTTP response to a 500 or whatever is applicable
            return Ok();
        }
    }
}
