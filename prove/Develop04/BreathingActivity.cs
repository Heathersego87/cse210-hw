public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity","This activity will help you relax with breathing techniques. Timed breathing can slow the heart rate and reset the nervous system.")
    {
    }
    public void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.WriteLine();
            Console.Write("Breathe in...");
            ShowCountDown(4);
            Console.WriteLine();
            Console.Write("Breathe out...");
            ShowCountDown(6);
        }
        Console.WriteLine();
        DisplayEndingMessage();
    }
}
