using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace knowledgebase.Data
{
    public class knowledgebaseService
    {
        private readonly IMongoCollection<knowledgebase> _knowledgebase;

        public knowledgebaseService(IOptions<knowledgebaseDbSettings> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            _knowledgebase = mongoClient.GetDatabase(options.Value.DatabaseName).GetCollection<knowledgebase>(options.Value.KnowledgebaseCollectionName);
        }
        public async Task<List<knowledgebase>> Get() => await _knowledgebase.Find(_ => true).ToListAsync();

        public async Task<knowledgebase> Get(string id) => await _knowledgebase.Find(m => m.Id == id).FirstOrDefaultAsync();
     }
}
    