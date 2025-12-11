using System;


namespace ToDoList.Models
{
    // Main domain model representing a single todo task
    public class TodoTask
    {
        // Unique identifier for each task
        public int Id { get; set; }

        // Task description - default to empty string to avoid null issues
        public string Title { get; set; } = string.Empty;

        // When the task should be completed
        public DateTime DueDate { get; set; }

        // Whether the task has been finished
        public bool IsCompleted { get; set; }

        // Which project this task belongs to
        public string Project { get; set; } = string.Empty;

        // How urgent this task is
        public Priority Priority { get; set; }

        // Computed property - automatically checks if task is past due and not done
        public bool IsOverdue => DueDate < DateTime.Now && !IsCompleted;

        // Default constructor - needed for JSON deserialization
        public TodoTask()
        {

        }

        // Constructor to create a new task with all required properties
        public TodoTask(string title, DateTime dueDate, string project, Priority priority)
        {
            Title = title;
            DueDate = dueDate;
            Project = project;
            Priority = priority;

        }
    }
}
