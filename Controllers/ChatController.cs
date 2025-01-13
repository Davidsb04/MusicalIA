using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Musicalia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreatePlaylist(string text)
        {
            try
            {

            }
            catch (Exception ex)
            {
                return BadRequest("Não foi possível criar a playlist. Erro: " +ex.Message);
            }
        }

    }
}
