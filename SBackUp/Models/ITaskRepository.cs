using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBackUp.Models
{
    public interface ITaskRepository
    {
        bool VeridyIfNotExist(Task task);
        void Add(Task task);
        void Edit(Task task);
        void Delete(Task task);
    }
}
