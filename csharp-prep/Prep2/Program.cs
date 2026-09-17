using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string input = Console.ReadLine();
        int gradePercentage = int.Parse(input);

        string letter;

        if (gradePercentage >= 90)
        {
            letter = "A";
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
        }
        else if (gradePercentage >=70)
        {
            letter = "C";
        }
        else if (gradePercentage >=60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        Console.WriteLine(letter);

        if (gradePercentage >=70)
        {
            Console.WriteLine("Congratulations! You're passing the class!");
        }
        else
        {
            Console.WriteLine("Try harder next time!");
        }
        if (gradePercentage >=90)
        {
            Console.WriteLine("Excellent!");
        }
        else if (gradePercentage >=80)
        {
            Console.WriteLine("Great Job!");
        }
        else if (gradePercentage >=70)
        {
            Console.WriteLine("Good Work!");
        }
        else if (gradePercentage >=60)
        {
            Console.WriteLine("Not your best work!");
        }
        else
        {
            Console.WriteLine("Dont give up!");
        }
    }
}