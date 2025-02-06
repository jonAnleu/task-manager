class TaskManager
{
  public List<Task> tasks = new();

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
    Console.WriteLine("\nTASK ADDED");
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
}
