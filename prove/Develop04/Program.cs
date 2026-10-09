using System;
//Heather Sego
// Creativity: Added a MeditationActivity as an extra activity beyond the core requirements.
class Program
{
    static void Main(string[] args)
    {
        string choice = "";

        while (choice != "5")
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Start Breathing Activity");
            Console.WriteLine("2. Start Reflecting Activity");
            Console.WriteLine("3. Start Listing Activity");
            Console.WriteLine("4. Start Meditation Activity");
            Console.WriteLine("5. Quit");
            Console.Write("Select an activity from the menu: ");

            choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity breathing = new BreathingActivity();
                breathing.Run();
            }
            else if (choice == "2")
            {
                ReflectingActivity reflecting = new ReflectingActivity();
                reflecting.Run();
            }
            else if (choice == "3")
            {
                ListingActivity listing = new ListingActivity();
                listing.Run();
            }
            else if (choice == "4")
            {
                MeditationActivity meditation = new MeditationActivity();
                meditation.Run();
            }
            else if (choice == "5")
            {
                Console.WriteLine("Thanks for relaxing with me today!");
            }
            else
            {
                Console.WriteLine("Please enter a number from 1-5.");
                ShowPause();
            }
        }
    }

    static void ShowPause()
    {
        Thread.Sleep(2000);
    }
}