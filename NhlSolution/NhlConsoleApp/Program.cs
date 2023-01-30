﻿// See https://aka.ms/new-console-template for more information

using NhlSystemClassLibrary;

// TODO 1: Create a new array with the names of 12 of your favorite game titles
string[] gameTitles = 
{
    "Mario Kart 8 Deluxe",
    "Super Mario Party",
    "Super Mario Odyseey",
    "New Super Mario Bros. U Deluxe",
    "Mario & Sonce at the Olypmics Games: Toyko 2021",
    "Super Mario Maker 2",
    "Mario + Rabbits Kingdom Battle",
    "Luigi's Manison 3",
    "Mario Tennis Aces",
    "Super Smash Bros Ultimate",
    "Mario Party Superstars",
    "Mario Kart 8 Deluxe"
};

// TODO 2: Print the name of each game title using a foreach loop 
Console.WriteLine("I am printing the name of each game title using a foreach loop.");
foreach (string currentGameTitle in gameTitles)
{
    Console.WriteLine(currentGameTitle);
}

// TODO 3: Print the name of each game title using a for loop
Console.WriteLine("I am printing the name of each game using a for loop");
for (int index = 0; index < gameTitles.Length; index++)
{
    Console.WriteLine(gameTitles[index]);
}

// TODO 4: Print the name of each title using the LinQ Enumerable ForEach method.
List<string> gameTitlesList = gameTitles.ToList();
Console.WriteLine("I am printing the name of each game using a Enumerable ForEach method");
gameTitlesList.ForEach(currentGameTitle => Console.WriteLine(currentGameTitle));

// TODO 5: Sort the game titles in ascending order then print the name of each game
// HINT: You can use the Order LinQ Numerable method
Console.WriteLine("I am printing the name of each game sorted ascending");
gameTitlesList
    .OrderBy(currentGameTitle => currentGameTitle)
    .ToList()
    .ForEach(currentGameTitle => Console.WriteLine(currentGameTitle));

// TODO 6: Use the LinQ Enumerable method Where to include only games with the Super keyword
Console.WriteLine("I am printing the name of each game that contains the Super keyword");
gameTitlesList.Where(currentGameTitle => currentGameTitle.Contains("Super"))
    .ToList()
    .ForEach(currentGameTitle => Console.WriteLine(currentGameTitle));

// TODO 7: Using the LinQ Enumerable method Any() to determine if any games contains the Mario title?
bool anyMarioTitle = gameTitlesList.Any(currentGameTitle => currentGameTitle.Contains("Mario"));
if (anyMarioTitle)
{
    Console.WriteLine("Yes there games with the title Mario");
}
else
{
    Console.WriteLine("No there no games with the title Mario");
}

// TODO 8: Using the LinQ Enumerable method Where() and First()/FirstOrDefault() to return the first game with the title "Super Mario"
//string? queryGameTitle = gameTitlesList
//    .Where(currentGame => currentGame.Contains("Super Mario"))
//    .FirstOrDefault();
string queryGameTitle = gameTitlesList
    .Where(currentGame => currentGame.Contains("Super Mario"))
    .First();
Console.WriteLine($"The first game title that contains Super Mario is {queryGameTitle} ");

// Prompt and read in the team name
//Console.Write("Enter the team name: ");
//string teamName = Console.ReadLine();
//try
//{
//    // Create a new Team instance
//    Team oilers = new Team("Oilers","Edmonton","Rogers Place", Conference.Western, Division.Pacific);
//    // Print the Team Name
//    //Console.WriteLine($"Team Name: {currentTeam.Name}");
//    Console.WriteLine(oilers);
//    //Console.WriteLine($"Name: {oilers.Name}, City: {oilers.City}, Arena: {oilers.Arena}");
//}
//catch(ArgumentNullException ex)
//{
//    Console.WriteLine(ex.Message);  
//}
//catch (ArgumentException ex)
//{
//    Console.WriteLine(ex.Message);
//}
//catch
//{
//    Console.WriteLine("Incorrect exception thrown");
//}

//
