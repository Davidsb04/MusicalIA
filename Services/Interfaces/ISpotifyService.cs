namespace Musicalia.Services.Interfaces
{
    public interface ISpotifyService
    {
        Task<String> GetSpotifyToken();
    }
}
