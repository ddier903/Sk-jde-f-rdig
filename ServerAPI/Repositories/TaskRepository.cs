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

    // Post Task:

    public async Task PostTask(TaskItem task)
    {
        await collection.InsertOneAsync(task);
    }

    // Update Task: 

    public async Task UpdateTask(string taskId, TaskItem updatedtask)
    {
        var filter = Builders<TaskItem>.Filter.Eq("TaskId", taskId);

        var update = Builders<TaskItem>.Update
       .Set(task => task.Status, updatedtask.Status)
       .Set(task => task.EndDate , updatedtask.EndDate)
       .Set(task => task.Comment, updatedtask.Comment);

        var result = await collection.UpdateOneAsync(filter, update);
    }

    // Delete Task: 

    public async Task DeleteTask(string taskId)
    {
        var filter = Builders<TaskItem>.Filter.Eq("TaskId", taskId);
        await collection.DeleteOneAsync(filter);
    }

    //Get All Task by ApartmentID:
    public async Task<List<TaskItem>> GetAllTaskByApartmentId(string id)
    {
        var filter = Builders<TaskItem>.Filter.Eq("Apartment.ApartmentId", id);
        return await collection.Find(filter).ToListAsync();
    }

    //Get Task by ApartmentID, sorted by Status: 


    //Get All Task by Subconctractor:
    public async Task<List<TaskItem>> GetAllTasksBySubcontractor(string id)
    {
        var filter = Builders<TaskItem>.Filter.Eq("Subcontractor.UserId", id);
        return await collection.Find(filter).ToListAsync();
    }

    // Get all Tasks:
    public async Task<List<TaskItem>> GetAllTasks()
    {
        var filter = Builders<TaskItem>.Filter.Empty;
        return await collection.Find(filter).ToListAsync();
    }

    // Get Task by Id: 
    public async Task<TaskItem> GetTaskById(string taskId)
    {
        var filter = Builders<TaskItem>.Filter.Eq("TaskId", taskId);
        return await collection.Find(filter).FirstOrDefaultAsync(); ;
    }

    // Get All Task by status:
    public async Task<List<TaskItem>> FilterTaskByStatus(string status)
    {
        var filter = Builders<TaskItem>.Filter.Eq("Status", status);
        return await collection.Find(filter).ToListAsync();
    }
}
