using Jr.Backend.Pessoa.Infrastructure.Repository.MongoDb.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jr.Backend.Pessoa.Infrastructure.Repository.MongoDb.Context
{
    public class MongoContext : IMongoContext
    {
        private IMongoDatabase Database { get; set; }
        public IClientSessionHandle Session { get; set; }
        public MongoClient MongoClient { get; set; }
        private readonly List<Func<Task>> commands;

        private IConfiguration configuration;

        /// <inheritdoc/>
        public MongoContext(IConfiguration configuration)
        {
            this.configuration = configuration;

            commands = new List<Func<Task>>();
        }

        public async Task<int> SaveChanges()
        {
            ConfigureMongo();

            using (Session = await MongoClient.StartSessionAsync())
            {
                Session.StartTransaction();

                var commandTasks = commands.Select(c => c());

                await Task.WhenAll(commandTasks);

                await Session.CommitTransactionAsync();
            }

            return commands.Count;
        }

        private void ConfigureMongo()
        {
            if (MongoClient != null)
            {
                return;
            }

            MongoClient = new MongoClient(configuration["MongoSettings:Connection"]);

            Database = MongoClient.GetDatabase(configuration["MongoSettings:DatabaseName"]);
        }

        /// <inheritdoc/>
        public IMongoCollection<T> GetCollection<T>(string name)
        {
            ConfigureMongo();

            return Database.GetCollection<T>(name);
        }

        /// <inheritdoc/>

        public void Dispose()
        {
            Session?.Dispose();
            GC.SuppressFinalize(this);
        }

        /// <inheritdoc/>

        public async Task AddCommand(Func<Task> func)
        {
            await Task.Run(() => commands.Add(func));
        }
    }
}