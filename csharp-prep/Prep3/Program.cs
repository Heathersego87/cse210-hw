using System;

class Program
{
    static void Main(string[] args)
    {
        
        Console.Write("What is your guess? ");
        string guess = Console.ReadLine();
        int firstGuess =  int.Parse(guess);

        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);

        while (firstGuess != magicNumber)
        {
            if (firstGuess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if(firstGuess > magicNumber)
            {
                Console.WriteLine("Lower");
            }

             Console.Write("Enter another guess:");
            firstGuess = int.Parse(Console.ReadLine());
    
        }
            Console.Write("You guessed it!");
        }
    }
