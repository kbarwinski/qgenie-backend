namespace QGenieBackend.Services
{
    public interface ILLMService
    {
        Task<string> SendQueryAsync(string prompt);
    }
}
