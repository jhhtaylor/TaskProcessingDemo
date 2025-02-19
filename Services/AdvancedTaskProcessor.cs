using TaskProcessingDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TaskProcessingDemo.Services
{
    // `sealed`: Prevents further inheritance (this is the final implementation)
    public sealed class AdvancedTaskProcessor : BaseTaskProcessor
    {
        // `override`: Provides a specific implementation for an abstract method
        public override void ProcessTasks(List<TaskItem> tasks)
        {
            // `Parallel.ForEach`: Runs operations on multiple threads for efficiency
            Parallel.ForEach(tasks, task =>
            {
                if (!_isRunning) return;

                // `lock`: Ensures that only one thread can modify the task at a time
                lock (_lockObj)
                {
                    task.StartTask();
                    Console.WriteLine($"Processing Task: {task}");
                    Thread.Sleep(500); // Simulates work
                    task.CompleteTask();
                    Console.WriteLine($"Completed Task: {task}");
                }
            });
        }
    }
}
