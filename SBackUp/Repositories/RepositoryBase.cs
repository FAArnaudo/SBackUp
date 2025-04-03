using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBackUp.Repositories
{
    public abstract class RepositoryBase
    {
        private readonly string connectionString;

        public RepositoryBase()
        {
            connectionString = $"Data Source='{AppDomain.CurrentDomain.BaseDirectory + "\\RepositoryBase\\" + "SBackUp_DDBB.db"}';Version=3;";
        }

        protected SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(connectionString);
        }
    }
}
