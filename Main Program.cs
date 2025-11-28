using System;
using System.Collections.Generic;

namespace EscapeRoomGame
{
class Program
{
static void Main(string[] args)
{
// create player 1 
Player player = new Player();
Console.WriteLine("--- WELCOME TO THE ANCIENT CAVE ESCAPE ---");
        Console.WriteLine("Goal: Solve the riddle in each room to advance.");
        // Starts with flashlight


        player.AddItem("Flashlight");
    

        // Setting up riddles
        Puzzle puzzle1 = new Puzzle();
        puzzle1.Question = "I speak without a mouth and hear without ears. I have no body, but I come alive with wind. What am I?";
        puzzle1.Answer = "echo";
        puzzle1.Hint = "It repeats what you say.";

        Puzzle puzzle2 = new Puzzle();
        puzzle2.Question = "What has keys but can't open locks?";
        puzzle2.Answer = "piano";
        puzzle2.Hint = "It is a musical instrument.";

        Puzzle finalPuzzle = new Puzzle();
        finalPuzzle.Question = "The more of this there is, the less you see. What is it?";
        finalPuzzle.Answer = "darkness";
        finalPuzzle.Hint = "Turn on your flashlight to see through this.";

        // creatingroom list
        List<Room> gameRooms = new List<Room>();
        
        // adding rooms
        Room entranceCave = new Room("The Entrance Cave", "It is damp and you hear dripping water.", puzzle1);
        gameRooms.Add(entranceCave);
        
        Room musicHall = new Room("The Music Hall", "An old room filled with dusty instruments.", puzzle2);
        gameRooms.Add(musicHall);
        
        Room voidRoom = new Room("The Void", "It is pitch black in here.", finalPuzzle);
        gameRooms.Add(voidRoom);

        // Main loop
        for(int roomIndex = 0; roomIndex < gameRooms.Count; roomIndex++)
        {
            Room currentRoom = gameRooms[roomIndex];
            

            Console.WriteLine("\n----------------------------------------");
            Console.WriteLine($"You have entered: {currentRoom.Name}");
            Console.WriteLine(currentRoom.Description);
            
            bool puzzleSolved = false;

            // loop until answer correct
            while (puzzleSolved == false)
            {
                Console.WriteLine($"\nRIDDLE: {currentRoom.RoomPuzzle.Question}");
                Console.Write("Type your answer or hint or inventory: ");
                string userInput = Console.ReadLine();

                if (userInput.ToLower() == "hint")
                {
                    Console.WriteLine($"HINT: {currentRoom.RoomPuzzle.Hint}");
                    continue; // Skip
                }
                 else if (userInput.ToLower() == "inventory")  // short command for inventory
                {
                    player.ShowInventory();
                    continue;
                }
                else if (currentRoom.RoomPuzzle.CheckAnswer(userInput))
                {
                    Console.WriteLine("Correct! The door unlocks.");
                
                    player.AddItem("Gold Coin");
                    puzzleSolved = true; // stop loop
                }

                else
                {
                    Console.WriteLine("Wrong answer. Try again.");
                
                }
            }
        }

        // game end message
        Console.WriteLine("\n----------------------------------------");
        Console.WriteLine("Congratulations! You have Finished the cave!");

        int totalItems = player.Inventory.Count;  // Storing
        Console.WriteLine($"You collected {totalItems} items.");
        player.ShowInventory();
        
        Console.ReadLine();
    }
}
}