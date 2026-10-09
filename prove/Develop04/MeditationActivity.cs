public class MeditationActivity : Activity
{
    private List<string> _meditationPrompts;

    public MeditationActivity() : base(
        "Meditation Activity",
        "This activity will help you slow down, clear your mind, and focus on happy thoughts."
    )
    {
        _meditationPrompts = new List<string>
        {
            "Focus on one thing you are grateful for.",
            "Think about a place where you feel completely safe.",
            "Focus on your breathing and relax your muscles.",
            "Think about one goal you want to accomplish.",
            "Reflect on a time in your life when you felt the Holy Ghost guide you."
        };
    }

    public string GetRandomMeditationPrompt()
    {
        Random random = new Random();
        int index = random.Next(_meditationPrompts.Count);

        return _meditationPrompts[index];
    }
    public void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
        Console.WriteLine();
        Console.WriteLine("Focus. Hold the thought in your mind:");
        Console.WriteLine();
        string prompt = GetRandomMeditationPrompt();
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine();
        Console.WriteLine("Relax and focus on this thought.");
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            ShowSpinner(3);
        }

        Console.WriteLine();
        DisplayEndingMessage();
    }   
}