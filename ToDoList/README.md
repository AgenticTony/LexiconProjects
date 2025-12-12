# 📝 Todo List Application

## Project Overview

A feature-rich console-based todo list application built in C# demonstrating solid software engineering principles, clean architecture, and modern C# development practices. This project showcases fundamental programming concepts including object-oriented design, file persistence, data management, and user interface development.

## 🎯 Project Requirements & Implementation

### Core Requirements ✅

| Requirement | Implementation | Status |
|-------------|----------------|---------|
| **Model a task with title, due date, status, and project** | `TodoTask` class with comprehensive properties including bonus features (Priority, IsOverdue) | 
| **Display tasks sorted by date and project** | Dedicated `TaskQueryService` with LINQ-based sorting algorithms | 
| **Add, edit, mark as done, and remove tasks** | Complete CRUD operations through `TaskManager` service | 
| **Text-based user interface** | Professional console UI with menu navigation, color coding, and input validation | 
| **Load and save task list to file** | JSON persistence with robust error handling via `FileHandler` |

### Bonus Features Implemented 🌟

- **Priority System**: Low, Medium, High priority levels
- **Overdue Detection**: Automatic identification of past-due incomplete tasks
- **Color-Coded Display**: Visual feedback (Green = Complete, Red = Overdue)
- **Input Validation**: Comprehensive validation for dates, IDs, and user inputs
- **Auto-Generated IDs**: Intelligent ID assignment system
- **Graceful Error Handling**: Robust handling of file operations and user input

## 🏗️ Technical Architecture

### Clean Architecture Implementation

```
┌─────────────────┐
│   UI Layer      │  ConsoleUI.cs
├─────────────────┤
│ Service Layer   │  TaskManager.cs, TaskQueryService.cs
├─────────────────┤
│  Data Layer     │  FileHandler.cs
├─────────────────┤
│ Domain Models   │  TodoTask.cs, Priority.cs
└─────────────────┘
```

### Key Design Decisions

- **Composition Over Inheritance**: Chose service composition for better maintainability
- **Separation of Concerns**: Read operations (TaskQueryService) separated from write operations (TaskManager)
- **Dependency Injection**: Services injected into UI layer for loose coupling
- **Single Responsibility Principle**: Each class has one clear purpose

## 📁 Project Structure

```
ToDoList/
├── Models/
│   ├── TodoTask.cs          # Core domain model
│   └── Priority.cs          # Priority enumeration
├── Services/
│   ├── TaskManager.cs       # Task CRUD operations
│   └── TaskQueryService.cs  # Read-only queries and sorting
├── Data/
│   └── FileHandler.cs       # JSON persistence layer
├── UI/
│   └── ConsoleUI.cs         # Console-based user interface
├── Program.cs               # Application entry point
└── tasks.json              # Data persistence file
```

## 💻 Technologies & Skills Demonstrated

### Core Technologies
- **.NET 8.0** - Latest framework features
- **C# 12** - Modern language features and idioms
- **System.Text.Json** - Built-in JSON serialization
- **LINQ** - Functional programming and data queries

### Programming Concepts Showcased
- **Object-Oriented Programming**: Encapsulation, composition
- **SOLID Principles**: Single Responsibility, Dependency Inversion
- **Error Handling**: Try-catch patterns, null-conditional operators
- **File I/O**: JSON serialization/deserialization
- **Collections**: Generic Lists with LINQ operations
- **Input Validation**: Date parsing, type validation
- **Modern C# Features**: Switch expressions, null-coalescing operators

## ✨ Key Features

### User Interface
- **Menu-Driven Navigation**: Intuitive console-based interface
- **Dynamic Task Counters**: Real-time pending/completed task counts
- **Professional Formatting**: Aligned columns with text truncation
- **Color-Coded Status**: Visual indicators for task states

### Task Management
- **Flexible Sorting**: Sort tasks by due date or project
- **Comprehensive Editing**: Update all task properties
- **Smart ID Generation**: Automatic unique ID assignment
- **Batch Operations**: Edit, complete, or delete tasks efficiently

### Data Persistence
- **JSON Storage**: Human-readable data format
- **Automatic Saving**: Data preserved on application exit
- **Graceful Loading**: Handles missing or corrupted files
- **File Path Configuration**: Customizable storage location

## 🚀 How to Run

### Prerequisites
- .NET 8.0 SDK or later

### Installation & Execution
```bash
# Clone the repository
git clone [repository-url]

# Navigate to project directory
cd TodoList/ToDoList

# Build the application
dotnet build

# Run the application
dotnet run
```

### Sample Usage Flow
```
>> Welcome to ToDoList
>> You have 1 tasks todo and 0 tasks are done!
>> Pick an option:
>> (1) Show Task List (by date or project)
>> (2) Add New Task
>> (3) Edit Task (update, mark as done, remove)
>> (4) Load Test Data (demo purposes)
>> (5) Save and Quit
```

## 🧪 Test Data for Demonstrations

The application includes comprehensive test data to showcase all features without manual setup:

### Quick Demo Instructions
1. Run the application: `dotnet run`
2. Select option **(4) Load Test Data**
3. Select option **(1) Show Task List** to see the formatted display
4. Try sorting by date (1) and project (2) to see different views

### Test Data Features
The `test-tasks.json` file includes **12 sample tasks** demonstrating:

- **✅ Completed Tasks**: Green color coding
- **🔴 Overdue Tasks**: Red color coding for past-due incomplete tasks
- **📊 Priority Levels**: Low, Medium, and High priority examples
- **📁 Multiple Projects**:
  - TodoList Development
  - Work Management
  - Learning
  - Personal
  - Bug Fixes
  - Code Quality
- **📅 Date Range**: Past, present, and future due dates
- **🎯 Real-world Tasks**: Authentic examples like "Fix authentication bug", "Schedule team meeting"

### Benefits for Recruiters
- **Immediate Functionality**: No need to create test data manually
- **Feature Showcase**: Demonstrates sorting, color coding, priorities
- **Professional Examples**: Shows understanding of software development workflows
- **Visual Appeal**: Color-coded display makes features obvious

## 📊 Code Quality Highlights

### Modern C# Idioms
```csharp
// Null-coalescing operators
string title = Console.ReadLine() ?? string.Empty;

// Switch expressions
Priority priority = input switch
{
    "1" => Priority.Low,
    "2" => Priority.Medium,
    "3" => Priority.High,
    _ => Priority.Medium
};

// LINQ for data operations
return tasks.OrderBy(t => t.DueDate).ToList();
```

### Robust Error Handling
```csharp
// Graceful file operations
if (!File.Exists(_filePath))
{
    return new List<TodoTask>();
}

// Input validation with TryParse
if (DateTime.TryParseExact(input, "yyyy-MM-dd", null,
   DateTimeStyles.None, out DateTime result))
{
    return result;
}
```

### Smart Domain Logic
```csharp
// Computed property for overdue detection
public bool IsOverdue => DueDate < DateTime.Now && !IsCompleted;

// Intelligent ID generation
private int GenerateNextId()
{
    return _tasks.Count == 0 ? 1 : _tasks.Max(t => t.Id) + 1;
}
```

## 🎓 Learning Outcomes

This project demonstrates proficiency in:

- **Clean Code Practices**: Readable, maintainable code with proper naming conventions
- **Architectural Thinking**: Layered architecture with clear separation of concerns
- **Modern C# Development**: Leveraging latest language features and best practices
- **User Experience**: Creating intuitive interfaces with proper feedback
- **Data Management**: Persistent storage with error handling
- **Software Design**: Making appropriate trade-offs for project scope and requirements

## 💡 Technical Decisions

### Why No Inheritance?
For this domain and project scope, composition was chosen over inheritance because:
- **Simple Domain**: Only one entity type (TodoTask) with no complex hierarchy
- **No Polymorphism Needed**: All tasks behave identically
- **Better Maintainability**: Services composition provides flexibility
- **Learning Focus**: Mastering fundamentals before advanced OOP patterns

This decision demonstrates understanding of when to apply different design patterns appropriately.

---

*This project showcases solid fundamentals in C# development, clean architecture, and software engineering best practices suitable for a junior to mid-level developer role.*
