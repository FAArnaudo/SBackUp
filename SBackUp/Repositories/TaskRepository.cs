using SBackUp.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBackUp.Repositories
{
    public class TaskRepository : RepositoryBase, ITaskRepository
    {
        public void Add(Task task)
        {
            throw new NotImplementedException();
        }

        public void Delete(Task task)
        {
            throw new NotImplementedException();
        }

        public void Edit(Task task)
        {
            throw new NotImplementedException();
        }

        public bool VeridyIfNotExist(Task task)
        {
            bool notExiste = false;

            using (SQLiteConnection connection = GetConnection())
            {
                using (SQLiteCommand command = new SQLiteCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Tasks " +
                                          "WHERE ";
                }
            }

            return notExiste;
            throw new NotImplementedException();
        }
    }
}
