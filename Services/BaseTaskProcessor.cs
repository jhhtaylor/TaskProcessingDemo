using TaskProcessingDemo.Models;
using System;
using System.Collections.Generic;
using System.Threading;

namespace TaskProcessingDemo.Services
{
    // `abstract`: Cannot be instantiated directly, must be inherited
    public abstract class BaseTaskProcessor : ITaskProcessor
    {
        // `readonly`: This field can only be assigned during declaration or in the constructor
        protected readonly object _lockObj = new object();

        // `volatile`: Ensures visibility of changes across multiple threads
        protected volatile bool _isRunning = true;

        // `abstract method`: Must be implemented by subclasses
        public abstract void ProcessTasks(List<TaskItem> tasks);

        // `virtual`: Provides a default implementation but can be overridden in subclasses
        public virtual async Task<int> GetCompletedTaskCountAsync(List<TaskItem> tasks)
        {
            return await Task.Run(() =>
            {
                // `lock`: Ensures thread safety
                lock (_lockObj)
                {
                    return tasks.Count(t => t.Status == Models.TaskStatus.Completed);
                }
            });
        }

        // Method to stop processing (used by `volatile _isRunning`)
        public void StopProcessing() => _isRunning = false;
    }
}
