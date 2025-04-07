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
        public TaskRepository()
        {

        }

        public void Add(TaskModel taskModel)
        {
            throw new NotImplementedException();
        }

        public bool DailyTaskVerify(string hours, string minutes, string seconds)
        {
            bool isOk = false;

            using (SQLiteConnection connection = GetConnection())
            {
                using (SQLiteCommand command = new SQLiteCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = $"SELECT * FROM Tasks " +
                                          $"WHERE frecuency_mode = 2 AND hours = '{hours}' AND minutes = '{minutes}' AND seconds = '{seconds}'";

                    isOk = command.ExecuteScalar() != null;
                }
            }

            return isOk;
        }

        public bool WeeklyTaskVerify(string day, string hours, string minutes, string seconds)
        {
            bool isOk = false;

            using (SQLiteConnection connection = GetConnection())
            {
                using (SQLiteCommand command = new SQLiteCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = $"SELECT * FROM Tasks " +
                                          $"WHERE frecuency_mode = 3 AND hours = '{hours}' AND minutes = '{minutes}' AND seconds = '{seconds}' AND week_day = '{day}'";
                }
            }

            return isOk;
        }

        public bool MonthlyTaskVerify(string day, string hours, string minutes, string seconds)
        {
            bool isOk = false;

            using (SQLiteConnection connection = GetConnection())
            {
                using (SQLiteCommand command = new SQLiteCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = $"SELECT * FROM Tasks " +
                                          $"WHERE frecuency_mode = 4 AND hours = '{hours}' AND minutes = '{minutes}' AND seconds = '{seconds}' AND month_day = {day}";
                }
            }

            return isOk;
        }

        public void Edit(TaskModel taskModel)
        {
            throw new NotImplementedException();
        }

        public TaskModel GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public TaskModel GetByName(string taskName)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
