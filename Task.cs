public class Task
{
  public string Category { get; set; }
  public string Title { get; set; }
  public string Details { get; set; }
  public bool IsCompleted { get; set; }

  public Task(string category, string title, string details)
  {
    Category = category;
    Title = title;  
    Details = details;
    IsCompleted = false;
  }
}