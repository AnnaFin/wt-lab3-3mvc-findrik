using wt_lab3_3mvc_findrik.Models;
namespace wt_lab3_3mvc_findrik.Views;
public class ItTaskView
{
    public void ShowTasks(List<ItTask> tasks)
    {
        Console.WriteLine("=== СПИСОК ЗАДАЧ ===");
        if (tasks.Count == 0)
        {
            Console.WriteLine("Задачи отсутствуют.");
            return;
        }

        foreach (var task in tasks)
        {
            Console.WriteLine(
                $"{task.Id}. {task.Title} | " +
                $"Проект: {task.ProjectName} | " +
                $"Приоритет: {task.Priority} | " +
                $"Часы: {task.EstimatedHours} | " +
                $"Выполнено: {(task.IsCompleted ? "Да" : "Нет")}");
        }
    }

    public void ShowTask(ItTask task)
    {
        Console.WriteLine("=== ЗАДАЧА ===");
        Console.WriteLine($"ID: {task.Id}");
        Console.WriteLine($"Название: {task.Title}");
        Console.WriteLine($"Проект: {task.ProjectName}");
        Console.WriteLine($"Приоритет: {task.Priority}");
        Console.WriteLine($"Оценка (часы): {task.EstimatedHours}");
        Console.WriteLine($"Выполнено: {(task.IsCompleted ? "Да" : "Нет")}");
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine($"[Сообщение] {message}");
    }
}