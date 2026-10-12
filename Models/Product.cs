namespace wt_lab3_3mvc_findrik.Models;
public class ItTask
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string ProjectName { get; set; } = "";
    public string Priority { get; set; } = "";
    public double EstimatedHours { get; set; }
    public bool IsCompleted { get; set; }
}