using System.IO;
public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    
    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    } 
    public void DisplayScore()
    {
        Console.WriteLine($"You have {_score} points.");
    }
    public void DisplayMenu()
    {
        Console.WriteLine();
        Console.WriteLine("Menu Options:");
        Console.WriteLine("  1. Create New Goal");
        Console.WriteLine("  2. List Goals");
        Console.WriteLine("  3. Save Goals");
        Console.WriteLine("  4. Load Goals");
        Console.WriteLine("  5. Record Event");
        Console.WriteLine("  6. View Goal Statistics");
        Console.WriteLine("  7. Quit");
        Console.Write("Select a choice from the menu: ");
    }  
    public void Start()
    {
        int choice = 0;
        while (choice != 7)
        {
            Console.WriteLine();
            DisplayScore();
            DisplayMenu();
            string input = Console.ReadLine();

            if (!int.TryParse(input, out choice))
            {
                Console.WriteLine("Please enter a valid number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    CreateGoal();
                    break;
                case 2:
                    ListGoals();
                    break;
                case 3:
                    SaveGoals();
                    break;
                case 4:
                    LoadGoals();
                    break;
                case 5:
                    RecordEvent();
                    break;
                case 6:
                    DisplayStatistics();
                    break;
                case 7:
                    Console.WriteLine("Thanks for setting goals today!");
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    } 
    
    public void CreateGoal()
    {
        Console.WriteLine("The goal choices are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which goal would you like to create? ");

        if (!int.TryParse(Console.ReadLine(), out int type) || type < 1 || type > 3)
        {
            Console.WriteLine("Invalid goal type.");
            return;
        }
            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine() ?? "";
            Console.Write("What is a short description of it? ");
            string description = Console.ReadLine() ?? "";
            Console.Write("How many points is this goal worth? ");

        if (!int.TryParse(Console.ReadLine(), out int points)|| points < 0)
        {
            Console.WriteLine("Invalid point value.");
            return;
        }
        if (type == 1)
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (type == 2)
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (type == 3)
        {
            Console.Write("How many times must this goal be completed? ");

            if (!int.TryParse(Console.ReadLine(), out int target)|| target <= 0)
            {
                Console.WriteLine("Invalid target.");
                return;
            }
            Console.Write("How many points for successfully completing the goal? ");

            if (!int.TryParse(Console.ReadLine(), out int bonus)|| bonus < 0)
            {
                Console.WriteLine("Invalid bonus.");
                return;
            }
            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
        Console.WriteLine("Goal successfully created!");
    }
    public void ListGoals()
    {
        Console.WriteLine();
        Console.WriteLine("Your Goals:");

        if (_goals.Count == 0)
        {
            Console.WriteLine("You have no goals yet.");
            return;
        }
        for (int i = 0; i < _goals.Count; i++)
        {
            Goal goal = _goals[i];
            string status = goal.IsComplete() ? "X" : " ";
            Console.WriteLine( $"{i + 1}. [{status}] {goal.GetDetailsString()}");
        }
    } 
    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You have no goals to record.");
            return;
        }
        ListGoals();
        Console.Write("Which goal did you accomplish? ");

        if (!int.TryParse(Console.ReadLine(), out int choice)|| choice < 1 || choice > _goals.Count)
        {
            Console.WriteLine("Invalid goal selection.");
            return;
        }
        Goal selectedGoal = _goals[choice - 1];
        int pointsEarned = selectedGoal.RecordEvent();
        _score += pointsEarned;
        Console.WriteLine($"Congratulations! You earned {pointsEarned} points!");
        DisplayScore();
    }  
    public void SaveGoals()
    {
        Console.Write("Enter the filename to save: ");
        string filename = Console.ReadLine() ?? "";
        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("Invalid filename.");
            return;
        }
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved successfully!");
    }  
    public void LoadGoals()
    {
        Console.Write("Enter the filename to load: ");
        string filename = Console.ReadLine() ?? "";
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }
        string[] lines = File.ReadAllLines(filename);
        if (lines.Length == 0 || !int.TryParse(lines[0], out int savedScore))
        {
            Console.WriteLine("Invalid save file.");
            return;
        }
        List<Goal> loadedGoals = new List<Goal>();
        try
        {
            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split('|');
                string type = parts[0];
                string name = parts[1];
                string description = parts[2];
                int points = int.Parse(parts[3]);
                if (type == "SimpleGoal")
                {
                    bool isComplete = bool.Parse(parts[4]);
                    loadedGoals.Add(new SimpleGoal(name, description, points, isComplete));
                }
                else if (type == "EternalGoal")
                {
                    loadedGoals.Add(new EternalGoal(name, description, points));
                }
                else if (type == "ChecklistGoal")
                {
                    int target = int.Parse(parts[4]);
                    int bonus = int.Parse(parts[5]);
                    int amountCompleted = int.Parse(parts[6]);
                    loadedGoals.Add(new ChecklistGoal(name, description, points,target, bonus, amountCompleted));
                }
                else
                {
                    throw new FormatException("Unknown goal type.");
                }
            }

            _goals = loadedGoals;
            _score = savedScore;
            Console.WriteLine("Goals loaded successfully!");
        }
        catch (Exception)
        {
            Console.WriteLine("The save file contains invalid goal data.");
        }
    }
    
    public void DisplayStatistics()
    {
        int totalGoals = _goals.Count;
        int completedGoals = 0;
        foreach (Goal goal in _goals)
        {
            if (goal.IsComplete())
            {
                completedGoals++;
            }
        }
        double percentage = 0;
        if (totalGoals > 0)
        {
            percentage = (double)completedGoals / totalGoals * 100;
        }
        Console.WriteLine();
        Console.WriteLine("===== Goal Statistics =====");
        Console.WriteLine($"Total Goals: {totalGoals}");
        Console.WriteLine($"Completed Goals: {completedGoals}");
        Console.WriteLine($"Incomplete Goals: {totalGoals - completedGoals}");
        Console.WriteLine($"Completion Rate: {percentage:F1}%");
        Console.WriteLine($"Total Points Earned: {_score}");
        Console.WriteLine("===========================");
    }
}
