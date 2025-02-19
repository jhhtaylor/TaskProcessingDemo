using TaskProcessingDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskProcessingDemo.Utilities
{
    public static class TaskFilter
    {
        public static List<TaskItem> GetHighPriorityTasks(List<TaskItem> tasks) =>
            tasks.Where(t => t.Priority > 5).OrderByDescending(t => t.Priority).ToList();

        public static void PrintTasks(List<TaskItem> tasks)
        {
            Console.WriteLine("\n=== Task List ===");
            tasks.ForEach(Console.WriteLine);
        }
    }
}
