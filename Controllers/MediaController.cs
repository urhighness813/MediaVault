using MediaVault.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MediaVault.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MediaController : ControllerBase
    {
        private readonly IMediaService _mediaSerivce;

        public MediaController(IMediaService mediaService)
        {
            _mediaSerivce = mediaService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var collection = _mediaSerivce.GetCollection();
            return Ok(collection);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return BadRequest("Query parameter is required.");
            
            var result = await _mediaSerivce.SearchAsync(query);

            if (result is null)
                return NotFound("No results found for the given query.");
                
            return Ok(result);
        }
    }
}