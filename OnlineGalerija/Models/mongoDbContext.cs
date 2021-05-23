using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGalerija.Models
{
    public class mongoDbContext
    {
        public MongoClient client;
        public IMongoDatabase database;
        public mongoDbContext()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            client = new MongoClient(configuration.GetConnectionString("MongoOnlineGalerija"));
            database = client.GetDatabase("OnlineGalerija");
        }
        

    }
}
