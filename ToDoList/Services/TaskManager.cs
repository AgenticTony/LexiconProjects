using System;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Services
{
    // Service class responsible for managing task operations (Create, Update, Delete)
    public class TaskManager
    {
        // Private list to store all tasks in memory
        private List<TodoTask> _tasks;

        // File handler dependency for saving/loading data
        private readonly FileHandler _fileHandler;

        // Constructor - initialize dependencies and empty task list
        public TaskManager()
        {
            _fileHandler = new FileHandler();
            _tasks = new List<TodoTask>();
        }

        // Public property to access the task list (read-only access)
        public List<TodoTask> Tasks => _tasks;

        // Save current tasks to file
        public void SaveTasks()
        {
            _fileHandler.Save(_tasks);
        }

        // Load tasks from file into memory
        public void LoadTasks()
        {
            _tasks = _fileHandler.Load();
        }

        // Load sample test data for demonstration purposes
        public void LoadTestData()
        {
            var testFileHandler = new FileHandler("test-tasks.json");
            _tasks = testFileHandler.Load();
        }

        // Add a new task with auto-generated ID
        public void AddTask(TodoTask task)
        {
            // Generate and assign unique ID
            task.Id = GenerateNextId();
            _tasks.Add(task);
        }

        // Update all properties of an existing task by ID
        public void UpdateTask(int id, string title, DateTime dueDate, string project, Priority priority)
        {
            // Find task with matching ID
            var task = _tasks.FirstOrDefault(t => t.Id == id);

            // Update properties if task exists
            if (task != null)
            {
                task.Title = title;
                task.DueDate = dueDate;
                task.Project = project;
                task.Priority = priority;
            }
        }

        // Mark a specific task as completed
        public void MarkAsDone(int id)
        {
            // Find task by ID
            var task = _tasks.FirstOrDefault(t => t.Id == id);

            // Set completed flag if task exists
            if (task != null)
            {
                task.IsCompleted = true;
            }
        }

        // Delete a task from the list
        public void RemoveTask(int id)
        {
            // Find task by ID
            var task = _tasks.FirstOrDefault(t => t.Id == id);

            // Remove from list if task exists
            if (task != null)
            {
                _tasks.Remove(task);
            }
        }

        // Helper method to create unique IDs for new tasks
        private int GenerateNextId()
        {
            // Start with ID 1 if no tasks exist
            if (_tasks.Count == 0)
            {
                return 1;
            }

            // Find highest existing ID and add 1
            return _tasks.Max(t => t.Id) + 1;
        }




    }
}