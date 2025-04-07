using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBackUp.Models
{
    public interface ITaskRepository
    {
        bool DailyTaskVerify(string hours, string minutes, string seconds);
        bool WeeklyTaskVerify(string day, string hours, string minutes, string seconds);
        bool MonthlyTaskVerify(string day, string hours, string minutes, string seconds);
        void Add(TaskModel taskModel);
        void Edit(TaskModel taskModel);
        void Remove(int id);
        TaskModel GetByID(int id);
        TaskModel GetByName(string taskName);

    }
}
