using SBackUp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBackUp
{
    public class TaskContainer
    {
        private static TaskContainer instance = null;
        public List<TaskModel> TaskModels { get; set; }
        private TaskContainer()
        {
            TaskModels = new List<TaskModel>();
        }

        public static TaskContainer Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TaskContainer();
                }

                return instance;
            }
        }

        public void AddTask(TaskModel taskModel)
        {
            TaskModels.Add(taskModel);
        }

        public TaskModel GetTask(string taskModelName)
        {
            TaskModel taskModel = null;

            try
            {
                taskModel = TaskModels.Find(p => p.TaskName.Equals(taskModelName));
            }
            catch (ArgumentNullException)
            {
                return null;
            }

            return taskModel;
        }

        public bool DeleteTask(string taskModelName)
        {
            TaskModel taskModel = null;

            try
            {
                foreach (TaskModel task in TaskModels)
                {
                    if (task.TaskName.Equals(taskModelName))
                    {
                        taskModel = task;
                        break;
                    }
                }

                return TaskModels.Remove(taskModel);
            }
            catch (NullReferenceException)
            {
                return false;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
        }
    }
}
