using MongoDB.Bson;
using MongoDB.Driver;
using QGenieBackend.POCOs;

namespace QGenieBackend.Contexts
{
    public class MongoDbContext
    {
        private readonly IMongoClient _client;
        private readonly IMongoDatabase _database;
        private readonly ILogger<MongoDbContext> _logger;

        // Cached collections
        private IMongoCollection<Interview> _interviews;
        private IMongoCollection<Candidate> _candidates;
        private IMongoCollection<Message> _messages;

        public MongoDbContext(IConfiguration configuration, ILogger<MongoDbContext> logger)
        {
            _logger = logger;

            var connectionString = Environment.GetEnvironmentVariable("MONGODB_CONNECTION_STRING");

            var settings = MongoClientSettings.FromConnectionString(connectionString);
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            settings.ServerSelectionTimeout = TimeSpan.FromSeconds(60);

            _client = new MongoClient(settings);
            _database = _client.GetDatabase("InterviewApp");

            // Send a ping to confirm a successful connection
            try
            {
                var result = _database.RunCommand<BsonDocument>(new BsonDocument("ping", 1));
                logger.LogInformation("Pinged your deployment. You successfully connected to MongoDB!");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Failed to ping your deployment. You may not be connected to MongoDB.");
            }
        }

        public IMongoCollection<Interview> Interviews =>
            _interviews ??= _database.GetCollection<Interview>("Interviews");

        public IMongoCollection<Candidate> Candidates =>
            _candidates ??= _database.GetCollection<Candidate>("Candidates");

        public IMongoCollection<Message> Messages =>
            _messages ??= _database.GetCollection<Message>("Messages");
    }
}
