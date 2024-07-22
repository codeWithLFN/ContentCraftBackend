using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class BlogPost
{
   [BsonId]
    public ObjectId Id { get; set; }
    
    [BsonElement("Title")]
    public string? Title { get; set; }
    
    
    [BsonElement("Content")]
    public string? Content { get; set; }
    
    [BsonElement("Author")]
    public Author? Author { get; set; }
    
    [BsonElement("PublishDate")]
    public DateTime PublishDate { get; set; }
}

public class Author
{
    [BsonElement("Name")]
    public string? Name { get; set; }
    
}