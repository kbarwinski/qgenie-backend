using OpenAI.Chat;

namespace QGenieBackend.Services
{
    public class OpenAILLMService : ILLMService
    {
        private readonly ChatClient _client;

        public OpenAILLMService(IConfiguration configuration)
        {
            var apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");
            _client = new(model: Environment.GetEnvironmentVariable("OPENAI_MODEL") ?? "gpt-4", apiKey);
        }

        public async Task<string> SendQueryAsync(string prompt)
        {
            ChatCompletion completion = _client.CompleteChat(prompt);
            return completion.ToString();
        }
    }
}
