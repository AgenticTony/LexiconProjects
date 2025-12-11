using System;
using System.Text.Json;
using ToDoList.Models;

namespace ToDoList.Data
{
    // Class responsible for saving and loading tasks to/from JSON file
    public class FileHandler
    {
        // File path where tasks are stored
        private readonly string _filePath;

        // JSON formatting options - indented for readable output
        private readonly JsonSerializerOptions _options = new()
        {
            WriteIndented = true
        };

        // Constructor with optional file path (defaults to "tasks.json")
        public FileHandler(string filePath = "tasks.json")
        {
            _filePath = filePath;
        }

        // Load tasks from JSON file, return empty list if file doesn't exist
        public List<TodoTask> Load()
        {
            // Check if file exists before trying to read
            if (!File.Exists(_filePath))
            {
                return new List<TodoTask>();
            }

            // Read entire file content as string
            string json = File.ReadAllText(_filePath);

            // Handle empty or whitespace-only files
            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<TodoTask>();
            }

            // Deserialize JSON string back to List<TodoTask>, with fallback to empty list
            return JsonSerializer.Deserialize<List<TodoTask>>(json, _options) ?? new List<TodoTask>();
        }

        // Save tasks list to JSON file
        public void Save(List<TodoTask> tasks)
        {
            // Convert tasks list to formatted JSON string
            string json = JsonSerializer.Serialize(tasks, _options);

            // Write JSON string to file (overwrites existing content)
            File.WriteAllText(_filePath, json);
        }
    }
}