using System;
namespace Hangman
{
	public class Player
	{
        
        // Properities
        public string UserName { get; private set; }
        
        // Constructor
        public Player(string userName)
        {
            this.UserName = userName;
        }

        int score;
        public int Score
        {
            get { return score; }
            set
            {
                if (value > 0)
                {
                    score = value;
                }
            }
        }
       
        public Dictionary<string, int> GuessesDict { get; } = new Dictionary<string, int>();

    }
}

	    