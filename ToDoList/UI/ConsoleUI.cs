using System;
using ToDoList.Models;
using ToDoList.Services;

namespace ToDoList.UI
{
    // Main user interface class that handles console interactions
    public class ConsoleUI
    {
        // Service for managing task operations
        private readonly TaskManager _taskManager;

        // Service for querying and sorting tasks
        private readonly TaskQueryService _queryService;

        // Flag to control the main application loop
        private bool _isRunning;

        // Constructor - initialize services and set running flag
        public ConsoleUI()
        {
            _taskManager = new TaskManager();
            _queryService = new TaskQueryService();
            _isRunning = true;
        }

        // Main application loop - loads data and handles user input
        public void Run()
        {
            // Load existing tasks from file on startup
            _taskManager.LoadTasks();

            // Main menu loop continues until user chooses to quit
            while (_isRunning)
            {
                ShowMainMenu();
                var choice = Console.ReadLine();

                // Handle user menu selection
                switch (choice)
                {
                    case "1":
                        ShowTaskList();
                        break;

                    case "2":
                        AddNewTask();
                        break;

                    case "3":
                        EditTask();
                        break;

                    case "4":
                        LoadTestData();
                        break;

                    case "5":
                        SaveAndQuit();
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        // Display the main menu with current task statistics
        private void ShowMainMenu()
        {
            Console.WriteLine();
            Console.WriteLine(">> Welcome to ToDoList");
            Console.WriteLine($">> You have {_queryService.GetPendingCount(_taskManager.Tasks)} tasks todo and {_queryService.GetCompletedCount(_taskManager.Tasks)} tasks are done!");
            Console.WriteLine(">> Pick an option:");
            Console.WriteLine(">> (1) Show Task List (by date or project)");
            Console.WriteLine(">> (2) Add New Task");
            Console.WriteLine(">> (3) Edit Task (update, mark as done, remove)");
            Console.WriteLine(">> (4) Load Test Data (demo purposes)");
            Console.WriteLine(">> (5) Save and Quit");
            Console.Write(">> ");
        }

        // Display all tasks with user-selected sorting option
        private void ShowTaskList()
        {
            Console.WriteLine();
            Console.WriteLine("Sort by (1) Date  (2) Project");
            Console.Write(">> ");
            var sortChoice = Console.ReadLine();

            // Get sorted task list based on user choice
            List<TodoTask> sortedTasks = sortChoice == "2"
            ? _queryService.GetSortedByProject(_taskManager.Tasks)
            : _queryService.GetSortedByDate(_taskManager.Tasks);

            // Handle empty task list
            if (sortedTasks.Count == 0)
            {
                Console.WriteLine(" No tasks found");
                return;
            }

            // Display table header
            Console.WriteLine();
            Console.WriteLine("ID | Title                | Due Date   | Project        | Priority | Status");
            Console.WriteLine(new string('-', 85));

            // Display each task in formatted table
            foreach (var task in sortedTasks)
            {
                DisplayTask(task);
            }
        }

        // Display a single task with color coding and formatting
        private void DisplayTask(TodoTask task)
        {
            // Save original console color to restore later
            var originalColour = Console.ForegroundColor;

            // Set color based on task status
            if (task.IsCompleted)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            }
            else if (task.IsOverdue)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            // Format text fields and truncate if too long
            string status = task.IsCompleted ? "Done" : "Pending";
            string title = task.Title.Length > 20 ? task.Title.Substring(0, 17) + "..." : task.Title;
            string project = task.Project.Length > 14 ? task.Project.Substring(0, 11) + "..." : task.Project;

            // Display formatted task row
            Console.WriteLine($"{task.Id,-3}| {title,-21}| {task.DueDate:yyyy-MM-dd} | {project,-15}| {task.Priority,-9}| {status}");

            // Restore original console color
            Console.ForegroundColor = originalColour;

        }

        // Collect user input and create a new task
        private void AddNewTask()
        {
            Console.WriteLine();
            Console.WriteLine("-- Add New Task --");

            // Get task title with validation
            Console.Write("Title: ");
            string title = Console.ReadLine() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("Title cannot be empty. Task not created.");
                return;
            }

            // Get due date using helper method
            DateTime dueDate = PromptForDate("Due Date (yyyy-MM-dd): ");

            // Get project name
            Console.Write("Project: ");
            string project = Console.ReadLine() ?? string.Empty;

            // Get priority using helper method
            Priority priority = PromptForPriority();

            // Create and add the new task
            var task = new TodoTask(title, dueDate, project, priority);
            _taskManager.AddTask(task);

            Console.WriteLine("Task added successfully!");
        }

        // Load demonstration data for testing and showcasing features
        private void LoadTestData()
        {
            _taskManager.LoadTestData();
            Console.WriteLine();
            Console.WriteLine("Test data loaded successfully!");
            Console.WriteLine("The test data includes:");
            Console.WriteLine("- Tasks with different priorities (Low/Medium/High)");
            Console.WriteLine("- Completed and pending tasks");
            Console.WriteLine("- Overdue tasks (shown in red)");
            Console.WriteLine("- Tasks from multiple projects");
            Console.WriteLine();
            Console.WriteLine("Try option (1) to view the tasks sorted by date or project!");
        }

        private void EditTask()
        {
            if (_taskManager.Tasks.Count == 0)
            {
                Console.WriteLine("No tasks to edit.");
                return;
            }

            ShowTaskList();

            Console.WriteLine();
            int id = PromptForTaskId("Enter Task ID to edit: ");

            var task = _queryService.GetTaskById(_taskManager.Tasks, id);

            if (task == null)
            {
                Console.WriteLine("Task not found!");
                return;
            }

            EditTaskSubMenu(task);
        }

        private void EditTaskSubMenu(TodoTask task)
        {
            Console.WriteLine();
            Console.WriteLine($"Editing Task: {task.Title}");
            Console.WriteLine("(1) Update Task Details");
            Console.WriteLine("(2) Mark as Done");
            Console.WriteLine("(3) Remove Task");
            Console.WriteLine("(4) Cancel");
            Console.Write(">> ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    UpDateTaskDetails(task);
                    break;

                case "2":
                    _taskManager.MarkAsDone(task.Id);
                    Console.WriteLine("Task marked as done!");
                    break;

                case "3":
                    _taskManager.RemoveTask(task.Id);
                    Console.WriteLine("Task removed!");
                    break;

                case "4":
                    Console.WriteLine("Edit Cancelled!");
                    break;

                default:
                    Console.WriteLine("Invalid Option");
                    break;
            }

        }

        private void UpDateTaskDetails(TodoTask task)
        {
            Console.WriteLine();
            Console.WriteLine("Leave blank to keep current value");

            Console.Write($"Title ({task.Title}): ");
            string titleInput = Console.ReadLine() ?? string.Empty;
            string title = string.IsNullOrWhiteSpace(titleInput) ? task.Title : titleInput;

            Console.Write($"Due Date ({task.DueDate:yyyy-MM-dd}): ");
            string dateInput = Console.ReadLine() ?? string.Empty;
            DateTime dueDate = string.IsNullOrWhiteSpace(dateInput) ? task.DueDate : ParseDate(dateInput) ?? task.DueDate;

            Console.Write($"Project ({task.Project})");
            string projectInput = Console.ReadLine() ?? string.Empty;
            string project = string.IsNullOrWhiteSpace(projectInput) ? task.Project : projectInput;

            Console.Write($"Priority ({task.Priority}): (1) Low  (2) Medium  (3) High  (Leave blank to keep)");
            Console.Write(">> ");
            string priorityInput = Console.ReadLine() ?? string.Empty;
            Priority priority = string.IsNullOrWhiteSpace(priorityInput) ? task.Priority : ParsePriority(priorityInput);

            _taskManager.UpdateTask(task.Id, title, dueDate, project, priority);
            Console.WriteLine("Task updated successfully");
        }

        private void SaveAndQuit()
        {
            _taskManager.SaveTasks();
            Console.WriteLine("Tasks saved. Goodbye!");
            _isRunning = false;
        }

        private DateTime PromptForDate(string message)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine() ?? string.Empty;

                DateTime? parsed = ParseDate(input);

                if (parsed.HasValue)
                {
                    return parsed.Value;
                }

                Console.WriteLine("Invalid date format. Please use yyyy-MM-dd.");
            }
        }

        private DateTime? ParseDate(string input)
        {
            if (DateTime.TryParseExact(input, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out DateTime result))
            {
                return result;
            }

            return null;
        }

        private Priority PromptForPriority()
        {
            Console.WriteLine("Priority: (1) Low (2) Medium (3) High");
            Console.Write(">> ");
            string input = Console.ReadLine() ?? string.Empty;

            return ParsePriority(input);
        }

        private Priority ParsePriority(string input)
        {
            return input switch
            {
                "1" => Priority.Low,
                "2" => Priority.Medium,
                "3" => Priority.High,
                _ => Priority.Medium
            };
        }

        private int PromptForTaskId(string message)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine() ?? string.Empty;

                if (int.TryParse(input, out int id))
                {
                    return id;
                }

                Console.WriteLine("Please enter a valid number. ");
            }
        }
    }
}