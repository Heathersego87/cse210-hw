using System;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
//HeatherSego

class Program
{
    static void Main(string[] args)
    {
        Fraction fraction1 = new Fraction();
        Fraction fraction2 = new Fraction(6);
        Fraction fraction3 = new Fraction(6,7);
        Fraction fraction4 = new Fraction();
        Random random = new Random();
        fraction1.SetTop(3);
        fraction1.SetBottom(4);
        Console.WriteLine(fraction1.GetTop());
        Console.WriteLine(fraction1.GetBottom());
        Console.WriteLine(fraction1.GetFractionString());
        Console.WriteLine(fraction1.GetDecimalValue());

        for (int i = 0; i < 20; i++)
        {
            int top = random.Next(1, 11);
            int bottom = random.Next(1, 11);
            fraction4.SetTop(top);
            fraction4.SetBottom(bottom);
            Console.WriteLine($"Fraction {i + 1}: string: {fraction4.GetFractionString()} Number: {fraction4.GetDecimalValue()}");
        }
    }
}