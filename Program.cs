using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskProcessingDemo.Models;
using TaskProcessingDemo.Services;
using TaskProcessingDemo.Utilities;

class Program
{
    static async Task Main()
    {
        List<TaskItem> tasks = new()
        {
            new TaskItem(1, "Fix Bug #101", 8),
            new TaskItem(2, "Implement Feature X", 6),
            new TaskItem(3, "Write Unit Tests", 4),
            new TaskItem(4, "Optimize Query", 9),
            new TaskItem(5, "Update Documentation", 3)
        };

        TaskFilter.PrintTasks(tasks);

        AdvancedTaskProcessor processor = new();
        processor.ProcessTasks(tasks);

        await Task.Delay(2000); // Wait for processing

        int completedCount = await processor.GetCompletedTaskCountAsync(tasks);
        Console.WriteLine($"\nCompleted Tasks: {completedCount}");

        TaskStatistics.PrintSummary(tasks);
    }
}
