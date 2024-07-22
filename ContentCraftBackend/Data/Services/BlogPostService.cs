using MongoDB.Driver;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

public class BlogPostService
{
    private readonly IMongoCollection<BlogPost> _blogPosts;

    public BlogPostService(IOptions<BlogDatabaseSettings> settings)
    {
        var client = new MongoClient(settings.Value.ConnectionString);
        var database = client.GetDatabase(settings.Value.DatabaseName);
        _blogPosts = database.GetCollection<BlogPost>(settings.Value.CollectionName);
    }

    public async Task<List<BlogPost>> GetAsync() => await _blogPosts.Find(_ => true).ToListAsync();

    public async Task<BlogPost> GetAsync(string id) => await _blogPosts.Find(post => post.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(BlogPost post) => await _blogPosts.InsertOneAsync(post);

    public async Task UpdateAsync(string id, BlogPost updatedPost) => await _blogPosts.ReplaceOneAsync(post => post.Id == id, updatedPost);

    public async Task RemoveAsync(string id) => await _blogPosts.DeleteOneAsync(post => post.Id == id);
}
