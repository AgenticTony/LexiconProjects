using ToDoList.UI;

namespace ToDoList;

// Main program entry point
class Program
{
    // Application entry point - creates and runs the console UI
    static void Main(string[] args)
    {
        // Create the main user interface
        var app = new ConsoleUI();

        // Start the application
        app.Run();
    }
}
