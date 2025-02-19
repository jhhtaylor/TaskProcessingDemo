using TaskProcessingDemo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskProcessingDemo.Services
{
    // `interface`: Defines a contract that must be implemented by any class that inherits from it
    public interface ITaskProcessor
    {
        // `void`: No return value
        void ProcessTasks(List<TaskItem> tasks);

        // `Task<int>`: An asynchronous method that returns an integer in the future
        Task<int> GetCompletedTaskCountAsync(List<TaskItem> tasks);
    }
}
