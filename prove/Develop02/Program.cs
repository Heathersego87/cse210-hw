using System;
using System.Security.Cryptography.X509Certificates;
//Heather Sego
//Exceeding requirements: Added a mood check-in and a thank-you message for journaling.
class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        List<string> prompts = new List<string>
        {
            "How did my day begin?",
            "What has been the most fulfilling part of my day thus far?",
            "How have I felt the Lord in my life today?",
            "What blessings have I been counting?",
            "Have my thoughts been negative or positive?",
            "Have I used the pattern interuptions methods to stay happy?"
        };
        string choice = "";
        while (choice!= "5")
        {
            Console.WriteLine("Please choose one of the following options:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.WriteLine("What would you like to do?");
            choice = Console.ReadLine();
            
            if (choice == "1")
            {
                Random random = new Random();
                int index = random.Next(prompts.Count);

                string prompt = prompts[index];

                Console.WriteLine(prompt);
                Console.Write(">");

                string response = Console.ReadLine();
                Console.WriteLine("How are feeling today?");

                string mood = Console.ReadLine();
                DateTime currentDate = DateTime.Now;

                string date = currentDate.ToShortDateString();
                Entry newEntry = new Entry();

                newEntry._date = date;
                newEntry._mood = mood;
                newEntry._promptText = prompt;
                newEntry._entryText = response;
                journal.AddEntry(newEntry);
            }
            else if (choice == "2")
            {
                journal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.WriteLine("What is the name of the file?");
                string filename = Console.ReadLine();
                journal.LoadFromFile(filename);
            }
            else if (choice == "4")
            {
                Console.WriteLine("What is the file name?");
                string filename = Console.ReadLine();
                journal.SaveToFile(filename);
            }
            else if (choice == "5")
            {
                Console.WriteLine("Thanks for writing in your journal today!");
            }
        }
    }
}