using MediaVault.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MediaVault.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MediaController : ControllerBase
    {
        private readonly IMediaService _mediaService;
        public MediaController(IMediaService mediaService)
        {
            _mediaService = mediaService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var collection = _mediaService.GetCollection();
            return Ok(collection);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return BadRequest("Query parameter is required.");
            
            var result = await _mediaService.SearchAsync(query);

            if (result is null)
                return NotFound("No results found for the given query.");

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddMediaRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.ImdbId) || string.IsNullOrWhiteSpace(request.Format))
                return BadRequest("ImdbId and Format are required.");

            var item = await _mediaService.AddAsync(request.ImdbId, request.Format);

            if (item is null)
                return NotFound("Media item could not be found with the given ImdbId.");

            return CreatedAtAction(nameof(GetAll), new { id = item.Id }, item);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var deleted = _mediaService.Remove(id);

            if (!deleted)
                return NotFound("Item not found in collection.");

            return NoContent();
        }
        public record AddMediaRequest(string ImdbId, string Format);

    }
}