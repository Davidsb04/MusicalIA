using Microsoft.AspNetCore.Mvc;
using Musicalia.Services.Interfaces;

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
        public async Task<IActionResult> GetSpotifyPlaylist(string query)
        {
            try
            {
                string playlistLink = await _spotifyService.GetPlaylistLink(query);

                if (playlistLink != string.Empty )
                    return Ok(playlistLink);

                return NotFound("Não foi possível retornar o link da playlist.");
            }
            catch (Exception ex)
            {
                return BadRequest("Não foi possível retornar uma playlist. Erro: " + ex.Message);
            }
        }

    }
}
