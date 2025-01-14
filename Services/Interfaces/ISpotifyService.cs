namespace Musicalia.Services.Interfaces
{
    public interface ISpotifyService
    {
        Task<String> GetPlaylistLink(string query);
    }
}
