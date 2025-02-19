using TaskProcessingDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TaskProcessingDemo.Services
{
    public class AdvancedTaskProcessor : BaseTaskProcessor
    {
        public override void ProcessTasks(List<TaskItem> tasks)
        {
            Parallel.ForEach(tasks, task =>
            {
                if (!_isRunning) return;

                lock (_lockObj)
                {
                    task.StartTask();
                    Console.WriteLine($"Processing Task: {task}");
                    Thread.Sleep(500); // Simulating work
                    task.CompleteTask();
                    Console.WriteLine($"Completed Task: {task}");
                }
            });
        }
    }
}
