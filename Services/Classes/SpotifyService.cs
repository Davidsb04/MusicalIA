using Musicalia.Services.Interfaces;
using SpotifyAPI.Web;

namespace Musicalia.Services.Classes
{
    public class SpotifyService : ISpotifyService
    {
        private readonly ITokenService _tokenManager;

        public SpotifyService(ITokenService tokenManager)
        {
            _tokenManager = tokenManager;
        }       

        public async Task<string> GetPlaylistLink(string query)
        {
            string externalUrl = string.Empty;
            string token = await _tokenManager.GetTokenAsync();
            var spotify = new SpotifyClient(token);
            int offSet = 0;
            bool playlistLinkIsValid = false;

            try
            {              
                SearchRequest request = new SearchRequest(SearchRequest.Types.Playlist, query)
                {
                    Limit = 1,
                    Offset = offSet
                };

                var searchResult = await spotify.Search.Item(request);

                var playlistLinks = searchResult.Playlists.Items
                    ?.Select(playlist => playlist.ExternalUrls!["spotify"])
                    .ToList();

                if (playlistLinks != null && playlistLinks.Any())
                {
                    foreach (var link in playlistLinks)
                    {
                        externalUrl = link;
                        break;
                    }
                }

                return externalUrl;
            }
            catch (NullReferenceException)
            {
                while (!playlistLinkIsValid)
                {
                    offSet++;

                    SearchRequest request = new SearchRequest(SearchRequest.Types.Playlist, query)
                    {
                        Limit = 1,
                        Offset = offSet
                    };

                    var searchResult = await spotify.Search.Item(request);

                    if (searchResult.Playlists.Items?[0] == null)
                        continue;                     

                    var playlistLinks = searchResult.Playlists.Items
                        .Select(playlist => playlist.ExternalUrls!["spotify"])
                        .ToList();

                    if (playlistLinks != null && playlistLinks.Any())
                    {
                        foreach (var link in playlistLinks)
                        {
                            externalUrl = link;
                            playlistLinkIsValid = true;
                            break;
                        }
                    }
                }

                return externalUrl;                
            }            
        }
    }
}
