using System;
using System.ComponentModel;
//Heather Sego

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment1 = new Assignment ("Heather Sego", "Inheritance"); 
        Console.WriteLine(assignment1.GetSummary());
        MathAssignment assignment2 = new MathAssignment ("Heather Sego", "Fractions", "3.1", "1-10");
        Console.WriteLine(assignment2.GetSummary());
        Console.WriteLine(assignment2.GetHomeworkList());
        WritingAssignment assignment3 = new WritingAssignment("Heather Sego","Music History","The Jazz Era");
        Console.WriteLine(assignment3.GetSummary());
        Console.WriteLine(assignment3.GetWritingInformation());
    }
}