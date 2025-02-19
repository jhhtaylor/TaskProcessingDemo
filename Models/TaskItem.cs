using System;

namespace TaskProcessingDemo.Models
{
    // `enum`: Defines a fixed set of named values (better than using magic numbers)
    public enum TaskStatus { Pending, InProgress, Completed }

    // `public`: Allows this class to be accessed from anywhere in the project
    public class TaskItem
    {
        // `private set;`: Allows only this class to modify `Status`, enforcing encapsulation
        public int Id { get; }
        public string Description { get; }
        public int Priority { get; }
        public TaskStatus Status { get; private set; }

        // `constructor`: Initializes properties when creating a new `TaskItem`
        public TaskItem(int id, string description, int priority)
        {
            Id = id;
            Description = description;
            Priority = priority;
            Status = TaskStatus.Pending; // Default status
        }

        // `void`: This method does not return a value
        public void StartTask() => Status = TaskStatus.InProgress;
        public void CompleteTask() => Status = Models.TaskStatus.Completed;

        // `override`: Modifies default `ToString()` behavior to return a custom string
        public override string ToString() => $"[{Id}] {Description} (Priority: {Priority}, Status: {Status})";
    }
}
