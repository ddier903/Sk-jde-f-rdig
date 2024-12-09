using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Core; 
namespace ServerAPI.Repositories;

public class TaskRepository
{
    private readonly string connectionString = "mongodb+srv://victorot:hvderkmn12345@cluster0.u4phc.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";
    private readonly IMongoClient mongoClient;
    private readonly IMongoDatabase database;
    private readonly IMongoCollection<TaskItem> collection;

    public TaskRepository()
    {
        mongoClient = new MongoClient(connectionString);
        database = mongoClient.GetDatabase("Skjøde");
        collection = database.GetCollection<TaskItem>("Task");
    }
}
