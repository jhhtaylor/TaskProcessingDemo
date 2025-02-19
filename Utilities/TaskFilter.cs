using TaskProcessingDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskProcessingDemo.Utilities
{
    // `static class`: Cannot be instantiated, only used for utility functions
    public static class TaskFilter
    {
        // `LINQ`: Filters and sorts tasks in one line
        public static List<TaskItem> GetHighPriorityTasks(List<TaskItem> tasks) =>
            tasks.Where(t => t.Priority > 5).OrderByDescending(t => t.Priority).ToList();

        // Prints tasks to the console
        public static void PrintTasks(List<TaskItem> tasks)
        {
            Console.WriteLine("\n=== Task List ===");
            tasks.ForEach(Console.WriteLine);
        }
    }
}
