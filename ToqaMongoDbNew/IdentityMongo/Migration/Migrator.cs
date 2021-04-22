using IdentityMongo.Model;
using IdentityMongo.Mongo;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityMongo.Migration
{
    internal static class Migrator
    {
        //Starting from 4 in case we want to implement migrations for previous versions
        public static int CurrentVersion = 4;

        public static async Task Apply(IMongoCollection<MigrationHistory> migrationCollection)
        {
            var history = (await migrationCollection.WhereAsync(x => true)).ToList();

            if (history.Count == 0)
            {
                await migrationCollection.InsertOneAsync(new MigrationHistory
                {
                    InstalledOn = DateTime.Now,
                    DatabaseVersion = CurrentVersion
                });

                //We have nothing to migrate yet but now we can introduce the first flag to recognize which version is installed
            }
        }
    }
}
