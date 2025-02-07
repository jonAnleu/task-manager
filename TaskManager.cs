using System.Linq.Expressions;
using Newtonsoft.Json;

class TaskManager
{
  private const string FilePath = "tasks.json";
  public List<Task> tasks = new();

  public TaskManager()
  {
    LoadTasks();
  }

  public void Run()
  {
    while (true)
    {
      Console.Clear();
      Console.WriteLine("\n-------------------");
      Console.WriteLine(" TASK MANAGER MENU");
      Console.WriteLine("-------------------\n");
      Console.WriteLine("1. Add Task");
      Console.WriteLine("2. Edit Task");
      Console.WriteLine("3. Display Tasks");
      Console.WriteLine("4. Exit");
      Console.Write("\nEnter a number (1-4) to choose an option: ");

      if (int.TryParse(Console.ReadLine(), out int option))
      {
        switch (option)
        {
          case 1:
            AddTask();
            break;
          case 2:
            EditTask();
            break;
          case 3:
            DisplayTasks();
            break;
          case 4:
            SaveTasks();
            Console.WriteLine("\nGoodbye!\n");
            return;
          default:
            Console.Clear();
            Console.WriteLine("\"INVALID ENTRY\" Please enter a number that corresponds to the menu options.");
            break;

        }
      }
      else
      {
        Console.Clear();
        Console.WriteLine("\"INVALID ENTRY\" Please enter a number that corresponds to the menu options.");
      }
      Console.Write("\nPress any key to continue...");
      Console.ReadKey();
    }
  }

  public void AddTask()
  {
    Console.Clear();
    Console.WriteLine("\n** ADD TASK INFO **\n");
    Console.Write("Category (Project, Personal, or Idea): ");
    string category = Console.ReadLine();
    Console.Write("Title: ");
    string title = Console.ReadLine();
    Console.Write("Details: ");
    string details = Console.ReadLine();

    tasks.Add(new Task(category, title, details));
    SaveTasks();

    Console.WriteLine("\nTASK ADDED!");
  }

  public void EditTask()
  {
    Console.WriteLine("Edit Task");
  }

  public void DisplayTasks()
  {
    Console.Clear();
    Console.WriteLine("\n** CURRENT TASKS **\n");

    if (tasks.Count == 0)
    {
      Console.WriteLine("No tasks available for display");
      return;
    }
    else
    {
      foreach (Task task in tasks)
      {
        Console.Write(task);
      }
    }
  }

  private void SaveTasks()
  {
    try
    {
      string json = JsonConvert.SerializeObject(tasks, Formatting.Indented);
      File.WriteAllText(FilePath, json);
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Error saving tasks: {ex.Message}");
    }
  }

  private void LoadTasks()
  {
    try
    {
      if (File.Exists(FilePath))
      {
        string json = File.ReadAllText(FilePath);
        tasks = JsonConvert.DeserializeObject<List<Task>>(json) ?? new List<Task>();
      }
    }
      catch (Exception ex)
      {
        Console.WriteLine($"Error loading tasks: {ex.Message}");
      }
    }
  }
