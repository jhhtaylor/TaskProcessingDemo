using AdvancedCSharpDemo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdvancedCSharpDemo.Services
{
    public interface ITaskProcessor
    {
        void ProcessTasks(List<TaskItem> tasks);
        Task<int> GetCompletedTaskCountAsync(List<TaskItem> tasks);
    }
}
