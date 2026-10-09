using System.Dynamic;

public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    public ReflectingActivity() : base("Reflecting Activity","This activity will help you reflect on good times in you life and help you count your blessings. This will help you recognize the positives in your life and help you become a powerhouse of a person.")
{
    _prompts = new List<string>
    {
        "Think of a time when you accomplished something amazing.",
        "Think of a time when you stood for what was right.",
        "Think of a time when you provided service to another person.",
        "Think of a time when you thought of others before yourself."
    };

    _questions = new List<string>
    {
        "Why was this experience impfactful to you?",
        "Was this the first time you've ever done something like this?",
        "Why did you decide to do this?",
        "How did you feel when it was finished?",
        "How was this experience different than other times you've done similar tasks?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself?",
        "How can you keep this experience in your mind for you to remember?"
    };
}
public string GetRandomQuestion()
    {
        Random random = new Random();
        int index = random.Next(_questions.Count);
        return _questions[index];
    }
public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
public void Run()
{
    DisplayStartingMessage();
    Console.WriteLine();
    Console.WriteLine("Ready...");
    ShowSpinner(3);
    Console.WriteLine();
    Console.WriteLine("Read the following prompt:");
    Console.WriteLine();
    string prompt = GetRandomPrompt();
    Console.WriteLine($"--- {prompt} ---");
    Console.WriteLine();
    Console.WriteLine("When you have something to say, press enter to continue.");
    Console.ReadLine();
    Console.WriteLine();
    Console.WriteLine("Now think on each of the following questions as they relate to this experience.");
    Console.Write("You can start in: ");
    ShowCountDown(5);
    Console.Clear();
    DateTime startTime = DateTime.Now;
    DateTime endTime = startTime.AddSeconds(_duration);

    while (DateTime.Now < endTime)
    {
        Console.Write($"> {GetRandomQuestion()} ");
        ShowSpinner(5);
        Console.WriteLine();
    }

    DisplayEndingMessage();
}
}