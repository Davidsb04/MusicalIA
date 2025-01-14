using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Musicalia.Services.Interfaces;
using Swan.Parsers;

namespace Musicalia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly ISpotifyService _spotifyService;

        public ChatController(ISpotifyService spotifyService)
        {
            _spotifyService = spotifyService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlaylist()
        {
            try
            {
                string token = await _spotifyService.GetAccessToken();

                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest("Não foi possível criar a playlist. Erro: " +ex.Message);
            }
        }

    }
}
