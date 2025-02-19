using System;

namespace AdvancedCSharpDemo.Models
{
    public enum TaskStatus { Pending, InProgress, Completed }

    public class TaskItem
    {
        public int Id { get; }
        public string Description { get; }
        public int Priority { get; }
        public TaskStatus Status { get; private set; }

        public TaskItem(int id, string description, int priority)
        {
            Id = id;
            Description = description;
            Priority = priority;
            Status = TaskStatus.Pending;
        }

        public void StartTask() => Status = TaskStatus.InProgress;
        public void CompleteTask() => Status = TaskStatus.Completed;

        public override string ToString() => $"[{Id}] {Description} (Priority: {Priority}, Status: {Status})";
    }
}
