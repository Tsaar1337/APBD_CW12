using APBD_CW12.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APBD_CW12.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
       
        private readonly ITripsService _tripsService;
        public TripsController(ITripsService tripsService)
        {
            _tripsService = tripsService;
        }

        [HttpGet]
        public async Task<IActionResult> getTrips([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var tripsWithPages = await _tripsService.GetTrips(page, pageSize);
            return Ok(tripsWithPages);
        }
        
    }
}
