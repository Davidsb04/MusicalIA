using Microsoft.AspNetCore.Mvc;
using Musicalia.Services.Interfaces;

namespace Musicalia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly ISpotifyService _spotifyService;
        private readonly IOllamaService _olamaService;

        public ChatController(ISpotifyService spotifyService, IOllamaService olamaService)
        {
            _spotifyService = spotifyService;
            _olamaService = olamaService;
        }

        [HttpPost("Chat")]
        public async Task<IActionResult> ChatOllama(string prompt)
        {
            try
            {
                string playlistLink = string.Empty;

                string response = await _olamaService.GetMusicalGenreByOllama(prompt);                

                if (response != string.Empty)
                    playlistLink = await _spotifyService.GetPlaylistLink(response);

                if (playlistLink != string.Empty)
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
