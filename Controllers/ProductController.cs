using wt_lab3_3mvc_findrik.Models;
using wt_lab3_3mvc_findrik.Views;
namespace wt_lab3_3mvc_findrik.Controllers;

public class ItTaskController
{
    private readonly List<ItTask> tasks;
    private readonly ItTaskView view;

    public ItTaskController()
    {
        tasks = new List<ItTask>
        {
            new ItTask { Id = 1, Title = "Разработка API", ProjectName = "CRM System", Priority = "High", EstimatedHours = 40, IsCompleted = false },
            new ItTask { Id = 2, Title = "Дизайн интерфейса", ProjectName = "CRM System", Priority = "Medium", EstimatedHours = 20, IsCompleted = true },
            new ItTask { Id = 3, Title = "Тестирование", ProjectName = "Mobile Banking", Priority = "High", EstimatedHours = 30, IsCompleted = false },
            new ItTask { Id = 4, Title = "Настройка CI/CD", ProjectName = "Mobile Banking", Priority = "Low", EstimatedHours = 15, IsCompleted = true }
        };
        view = new ItTaskView();
    }

    public void Index()
    {
        view.ShowTasks(tasks);
    }

    public void Show(int id)
    {
        var task = tasks.FirstOrDefault(t => t.Id == id);
        if (task == null)
        {
            view.ShowMessage("Задача не найдена.");
            return;
        }
        view.ShowTask(task);
    }

    public void Add(ItTask task)
    {
        tasks.Add(task);
        view.ShowMessage("Задача успешно добавлена.");
    }

    public void Delete(int id)
    {
        var task = tasks.FirstOrDefault(t => t.Id == id);
        if (task == null)
        {
            view.ShowMessage("Задача не найдена.");
            return;
        }
        tasks.Remove(task);
        view.ShowMessage("Задача успешно удалена.");
    }
    public void FilterByProject(string projectName)
    {
        var filtered = tasks
            .Where(t => t.ProjectName.Contains(projectName, StringComparison.OrdinalIgnoreCase))
            .ToList();

        if (filtered.Count == 0)
        {
            view.ShowMessage("Задачи по этому проекту не найдены.");
            return;
        }

        view.ShowTasks(filtered);
    }

    public void Run()
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("=== МЕНЮ ===");
            Console.WriteLine("1. Показать все задачи");
            Console.WriteLine("2. Найти задачу по ID");
            Console.WriteLine("3. Добавить задачу");
            Console.WriteLine("4. Удалить задачу");
            Console.WriteLine("5. Фильтр по проекту");
            Console.WriteLine("0. Выход");
            Console.Write("Выберите действие: ");

            var command = Console.ReadLine();

            switch (command)
            {
                case "1":
                    Index();
                    break;
                case "2":
                    ShowTaskByUserInput();
                    break;
                case "3":
                    AddTaskByUserInput();
                    break;
                case "4":
                    DeleteTaskByUserInput();
                    break;
                case "5":
                    FilterByProjectByUserInput();
                    break;
                case "0":
                    Console.WriteLine("Выход из программы.");
                    return;
                default:
                    view.ShowMessage("Неизвестная команда.");
                    break;
            }
        }
    }

    private void ShowTaskByUserInput()
    {
        Console.Write("Введите ID задачи: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            view.ShowMessage("Некорректный ID.");
            return;
        }
        Show(id);
    }

    private void AddTaskByUserInput()
    {
        Console.Write("Введите ID: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            view.ShowMessage("Некорректный ID.");
            return;
        }

        Console.Write("Введите название задачи: ");
        string title = Console.ReadLine() ?? "";

        Console.Write("Введите название проекта: ");
        string project = Console.ReadLine() ?? "";

        Console.Write("Введите приоритет (High/Medium/Low): ");
        string priority = Console.ReadLine() ?? "Medium";

        Console.Write("Введите оценку в часах: ");
        if (!double.TryParse(Console.ReadLine(), out double hours))
        {
            view.ShowMessage("Некорректная оценка часов.");
            return;
        }

        Console.Write("Задача выполнена? (y/n): ");
        bool isCompleted = Console.ReadLine()?.ToLower() == "y";

        var newTask = new ItTask
        {
            Id = id,
            Title = title,
            ProjectName = project,
            Priority = priority,
            EstimatedHours = hours,
            IsCompleted = isCompleted
        };

        Add(newTask);
    }

    private void DeleteTaskByUserInput()
    {
        Console.Write("Введите ID задачи для удаления: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            view.ShowMessage("Некорректный ID.");
            return;
        }
        Delete(id);
    }

    private void FilterByProjectByUserInput()
    {
        Console.Write("Введите название проекта для фильтрации: ");
        string project = Console.ReadLine() ?? "";
        FilterByProject(project);
    }
}