using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is the magic number?");
        string magicNumber = Console.ReadLine();
        int firstNumber =  int.Parse(magicNumber);

        Console.Write("What is your guess? ");
        string guess = Console.ReadLine();
        int firstGuess =  int.Parse(guess);

        while (firstGuess != firstNumber)
        {
            if (firstGuess < firstNumber)
            {
                Console.WriteLine("Higher");
            }
            else if(firstGuess > firstNumber)
            {
                Console.WriteLine("Lower");
            }

             Console.Write("Enter another guess:");
            firstGuess = int.Parse(Console.ReadLine());
    
        }
            Console.Write("You guessed it!");
        }
    }
