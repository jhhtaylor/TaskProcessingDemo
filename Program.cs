using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskProcessingDemo.Models;
using TaskProcessingDemo.Services;
using TaskProcessingDemo.Utilities;

class Program
{
    // `async`: Allows for asynchronous execution
    static async Task Main()
    {
        // `List<T>`: A generic collection holding `TaskItem` objects
        List<TaskItem> tasks = new()
        {
            new TaskItem(1, "Fix Bug #101", 8),
            new TaskItem(2, "Implement Feature X", 6),
            new TaskItem(3, "Write Unit Tests", 4),
            new TaskItem(4, "Optimize Query", 9),
            new TaskItem(5, "Update Documentation", 3)
        };

        // Prints initial tasks
        TaskFilter.PrintTasks(tasks);

        // `AdvancedTaskProcessor`: Uses multi-threading to process tasks
        AdvancedTaskProcessor processor = new();
        processor.ProcessTasks(tasks);

        // `await Task.Delay`: Waits for tasks to finish asynchronously
        await Task.Delay(2000);

        // `await`: Calls an async method and waits for its result
        int completedCount = await processor.GetCompletedTaskCountAsync(tasks);
        Console.WriteLine($"\nCompleted Tasks: {completedCount}");

        // Prints final summary
        TaskStatistics.PrintSummary(tasks);
    }
}
