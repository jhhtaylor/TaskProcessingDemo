using TaskProcessingDemo.Models;
using System;
using System.Collections.Generic;
using System.Threading;

namespace TaskProcessingDemo.Services
{
    public abstract class BaseTaskProcessor : ITaskProcessor
    {
        protected readonly object _lockObj = new object();
        protected volatile bool _isRunning = true;

        public abstract void ProcessTasks(List<TaskItem> tasks);

        public virtual async Task<int> GetCompletedTaskCountAsync(List<TaskItem> tasks)
        {
            return await Task.Run(() =>
            {
                lock (_lockObj)
                {
                    return tasks.Count(t => t.Status == Models.TaskStatus.Completed);
                }
            });
        }

        public void StopProcessing() => _isRunning = false;
    }
}
