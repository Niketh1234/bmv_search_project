using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SearchService.Services;

namespace SearchService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        SearchableService _service;
        public SearchController( SearchableService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult Get([FromQuery] string q) 
        {
            var results = _service.Get(q);
            return Ok(results);
        }
    }
}
