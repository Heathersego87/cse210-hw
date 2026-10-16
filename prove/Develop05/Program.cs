using System;
//Heather Sego
//Creativity: I added a Goal Statistics feature that goes beyond the core requirements. Users can view their total goals, completed goals, incomplete goals, completion percentage, and total points earned.
//This feature uses polymorphism by calling IsComplete() on different goal types to calculate overall progress.
class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        goalManager.Start();
    }
}