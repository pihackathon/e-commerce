using System;
using System.Collections.Generic;
using System.Text;

namespace PI.ECommerceService.Core.Configuration
{
    public class MongoDBSettings
    {
        public MongoDBSettings(string dbName)
        {
            this.DbName = dbName;
        }

        public string DbName { get; }
    }
}
