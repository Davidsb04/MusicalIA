namespace Musicalia.Services.Interfaces
{
    public interface IOllamaService
    {
        public Task<string> GetMusicalGenreByOllama(string UserRequest);
    }
}
