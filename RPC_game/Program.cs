using System;

class program
{
    enum Choice { Rock = 1, Paper, Scissors }

    static void Main()
    {
        int userScore = 0, computerScore = 0;
        Random rand = new Random();
        bool playAgain = true;

        Console.WriteLine("🎮 Welcome to Rock, Paper, Scissors!");

        while (playAgain)
        {
            Console.WriteLine("\nChoose:");
            Console.WriteLine("1. Rock");
            Console.WriteLine("2. Paper");
            Console.WriteLine("3. Scissors");
            Console.Write("Your choice: ");

            bool validInput = int.TryParse(Console.ReadLine(), out int userInput);

            if (!validInput || userInput < 1 || userInput > 3)
            {
                Console.WriteLine("❌ Invalid choice. Try again.");
                continue;
            }

            Choice userChoice = (Choice)userInput;
            Choice computerChoice = (Choice)rand.Next(1, 4);

            Console.WriteLine($"🤖 Computer chose: {computerChoice}");

            if (userChoice == computerChoice)
            {
                Console.WriteLine("🤝 It's a draw!");
            }
            else if (
                (userChoice == Choice.Rock && computerChoice == Choice.Scissors) ||
                (userChoice == Choice.Paper && computerChoice == Choice.Rock) ||
                (userChoice == Choice.Scissors && computerChoice == Choice.Paper)
            )
            {
                Console.WriteLine("✅ You win this round!");
                userScore++;
            }
            else
            {
                Console.WriteLine("❌ You lose this round!");
                computerScore++;
            }

            Console.WriteLine($"🏆 Score - You: {userScore} | Computer: {computerScore}");

            Console.Write("\n🔁 Play again? (y/n): ");
            playAgain = Console.ReadLine().ToLower() == "y";
        }

        Console.WriteLine("\n🎉 Final Score:");
        Console.WriteLine($"You: {userScore} | Computer: {computerScore}");
        Console.WriteLine("👋 Thanks for playing!");
    }
}
