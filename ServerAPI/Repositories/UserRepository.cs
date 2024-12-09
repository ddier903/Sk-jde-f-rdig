using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using Core;
using Microsoft.AspNetCore.Identity;
using System.Reflection;
namespace ServerAPI.Repositories;



public class UserRepository
{
    private readonly string connectionString = "mongodb+srv://victorot:hvderkmn12345@cluster0.u4phc.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";
    private readonly IMongoClient mongoClient;
    private readonly IMongoDatabase database;
    private readonly IMongoCollection<User> collection;

    public UserRepository()
    {
        mongoClient = new MongoClient(connectionString);
        database = mongoClient.GetDatabase("Skjøde");
        collection = database.GetCollection<User>("User");
    }

	//Add User
	public async Task PostUser(User user)
	{
		await collection.InsertOneAsync(user);
	}
	//Delete User
	public async Task DeleteUSer(int userId)
	{
		var filter = Builders<User>.Filter.Eq("UserId", userId);
		await collection.DeleteOneAsync(filter);
	}
	//Update User
	public async Task UpdateUser(int userId, User updateduser)
	{
		var filter = Builders<User>.Filter.Eq("UserId", userId);

		var update = Builders<User>.Update
	   .Set(user => user.Phone, updateduser.Phone)
	   .Set(user => user.Email, updateduser.Email);
	 
	}

	//Get User by Username and Password
	public async Task<User> GetUserByUsernameAndPassword(string username, string password)
	{
		var filter1 = Builders<User>.Filter.Eq("UserName", username);
		var filter2 = Builders<User>.Filter.Eq("Password", password);
		var combinedfilter = Builders<User>.Filter.And(
		filter1,
		filter2
		);

		return await collection.Find(combinedfilter).FirstOrDefaultAsync(); ;
	}
	//Get User by UserID
	public async Task<User> GetUserById(int userId)
	{
		var filter = Builders<User>.Filter.Eq("UserId", userId);
		return await collection.Find(filter).FirstOrDefaultAsync();
	}

	//Get Subcontractors
	public async Task<List<User>> GetAllSubcontractors()
	{
		string role = "Subcontractor";
		var filter = Builders<User>.Filter.Eq("Role", role);
		return await collection.Find(filter).ToListAsync();
	}
}