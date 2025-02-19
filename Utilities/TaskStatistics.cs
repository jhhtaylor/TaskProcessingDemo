using AdvancedCSharpDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvancedCSharpDemo.Utilities
{
    public static class TaskStatistics
    {
        public static double GetAveragePriority(List<TaskItem> tasks) =>
            tasks.Any() ? tasks.Average(t => t.Priority) : 0;

        public static void PrintSummary(List<TaskItem> tasks)
        {
            Console.WriteLine($"\nTotal Tasks: {tasks.Count}");
            Console.WriteLine($"Completed Tasks: {tasks.Count(t => t.Status == Models.TaskStatus.Completed)}");
            Console.WriteLine($"Average Priority: {GetAveragePriority(tasks):0.00}");
        }
    }
}
