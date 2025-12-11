using System;
using ToDoList.Models;

namespace ToDoList.Services
{
    // Service class for read-only task operations and queries
    public class TaskQueryService
    {
        // Find a specific task by its unique ID
        public TodoTask? GetTaskById(List<TodoTask> tasks, int id)
        {
            return tasks.FirstOrDefault(t => t.Id == id);
        }

        // Sort tasks by due date (earliest first)
        public List<TodoTask> GetSortedByDate(List<TodoTask> tasks)
        {
            return tasks.OrderBy(t => t.DueDate).ToList();
        }

        // Sort tasks alphabetically by project name
        public List<TodoTask> GetSortedByProject(List<TodoTask> tasks)
        {
            return tasks.OrderBy(t => t.Project).ToList();
        }

        // Count how many tasks are not yet completed
        public int GetPendingCount(List<TodoTask> tasks)
        {
            return tasks.Count(t => !t.IsCompleted);
        }

        // Count how many tasks have been completed
        public int GetCompletedCount(List<TodoTask> tasks)
        {
            return tasks.Count(t => t.IsCompleted);
        }
    }
}