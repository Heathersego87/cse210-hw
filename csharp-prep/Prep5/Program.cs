using System;
using System.ComponentModel.DataAnnotations;
//Heather Sego
class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();

        string userName = PromptUserName();
        int userNumber = PromptUserNumber();
        int squaredNumber = SquareNumber(userNumber);
        int birthYear;
        PromptUserBirthYear(out birthYear);

        DisplayResult(userName, squaredNumber, birthYear);
        
         static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the program! Lets get started!");
        }
    static string PromptUserName()
        {
            Console.Write("What is your name?");
            string name = Console.ReadLine();
            return name;
        }
        static int PromptUserNumber()
        {
            Console.Write("What is your favorite number?");
            int number = int.Parse(Console.ReadLine());
            return number;
        }
        static void PromptUserBirthYear(out int birthYear)
        {
            
            Console.Write("What year were you born?");
            birthYear = int.Parse(Console.ReadLine());
        }
        static int SquareNumber(int number)
        {
            int square = number * number;
            return square;
        }
        static void DisplayResult(string name, int square, int birthYear)
        {
            Console.WriteLine($"{name}, the square of your number is {square}.");
            Console.WriteLine($"{name}, you will turn {2026 - birthYear} years old this year. Happy birthday!");
        }
    }
}