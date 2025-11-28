using System;

namespace EscapeRoomGame
{
    class Room
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Puzzle RoomPuzzle { get; set; }

        // Constructor for rooms
        public Room(string name, string desc, Puzzle puzzle)
        {
            Name = name;
            Description = desc;
            RoomPuzzle = puzzle;
        }
    }
}