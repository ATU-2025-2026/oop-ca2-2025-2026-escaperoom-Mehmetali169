using System;

namespace EscapeRoomGame
{
    class Puzzle
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public string Hint { get; set; }



        // function so ssee if answer corrrect
        public bool CheckAnswer(string input)
        {
            // converts input to lowercase
            if (string.IsNullOrEmpty(input)) return false;
            
            return input.Trim().ToLower() == Answer.ToLower();
        }
    }
}