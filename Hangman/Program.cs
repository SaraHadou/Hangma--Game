namespace Hangman;
class Program
{
    static string correctWord;
    static char[] letters;
    static Player player;

    // Entry 
    static void Main(string[] args)
    {
        StartGame();
        PlayGame();
        EndGame();
    }

    // Start Game
    private static void StartGame()
    {
        try
        {
            var listOfWords = File.ReadAllLines("/Users/saraelaraby/Projects/Wrds.txt");

            Random random = new Random();
            correctWord = listOfWords[random.Next(listOfWords.Length)];
        }
        catch (FileNotFoundException)
        {
            string[] listOfWords = { "flower", "Tshirt", "apple" };

            Random random = new Random();
            correctWord = listOfWords[random.Next(listOfWords.Length)];
        }
        catch (Exception ex)
        {
            Console.WriteLine("Something went wrong! please try again later.");
        }
        
        letters = new char[correctWord.Length];
        for (int i = 0; i < correctWord.Length; i++)
            letters[i] = '-';

        AskForUserName();
    }

    private static void AskForUserName()
    {

        Console.WriteLine("Enter your name:");
        string input = Console.ReadLine();

        if (input.Length >= 2)
            player = new Player(input);
        else
            AskForUserName();
    }

    // Play Game
    private static void PlayGame()
    {
        do
        {
            Console.Clear();
            DisplayMaskedWord();
            string letter = AskForLetter();
            CheckLetter(letter[0]);
        } while (correctWord != new string(letters));
        Console.Clear();
    }

    private static void DisplayMaskedWord()
    {
        foreach (char c in letters)
            Console.Write(c);
        Console.WriteLine();
    }

    private static string AskForLetter()
    {
        string input;        
        do
        {
            Console.WriteLine("Enter a letter:");
            input = Console.ReadLine();
        } while (input.Length != 1);

        if (!player.GuessesDict.Keys.Contains(input))
            player.GuessesDict.Add(input, 0);
        else
            player.GuessesDict[input] += 1;

        return input;
    }

    private static void CheckLetter(char letter)
    { 
        for (int i = 0; i < correctWord.Length; i++)
        {
            if (letter == correctWord[i])
            {
                letters[i] = letter;
                player.Score++;
            }
        }   
    }

    // End Game
    private static void EndGame()
    {
        Console.WriteLine("....... Congratulations .......");
        Console.WriteLine($"Thanks for playing {player.UserName}");
        Console.WriteLine($"Guesses:{player.GuessesDict.Count}  Score:{player.Score}");
    }

}

