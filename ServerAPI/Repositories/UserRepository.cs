﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using Core; 
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
        //collection = database.GetCollection<User>("User"); mangler navn i krokodillemunden
    }

    //Add User
    //Delete User
    //Update User

    //Get User by Username and Password
    //Get USer by UserID
}