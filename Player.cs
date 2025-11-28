using System;
using System.Collections.Generic; // Needed for Lists

namespace EscapeRoomGame
{
    class Player
    {
        public List<string> Inventory { get; set; } = new List<string>();

        public void AddItem(string item)
        {
            Inventory.Add(item);
            Console.WriteLine($"You, picked up: {item}");
        }

        public void ShowInventory()
        {
            Console.WriteLine("Current inventory: " + string.Join(", ", Inventory));
        }
    }
}