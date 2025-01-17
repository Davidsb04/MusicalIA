namespace Musicalia.Services.Interfaces
{
    public interface ITokenService
    {
        public Task<string> GetTokenAsync();
    }
}
