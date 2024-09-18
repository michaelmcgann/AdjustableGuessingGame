namespace DiceGame;

public class PlayGame {


    public void StartGame() {
        while (true) {
            
            GameInterface.PrintStartingMessage("Welcome to Guess The Number. Pick your boundaries, your starting lives" +
                                               " are based on the size of your range.");
            
            
            SetBoundaries(out int lowerBound, out int higherBound);
            
            GameState game = new GameState(lowerBound, higherBound);


            TakeGuesses(game);

            bool wantsAnotherGame = PromptForAnotherGame();
            if (wantsAnotherGame) {
                continue;
            }

            break;

        }
    }

    private static void TakeGuesses(GameState game) {
        do {
            Console.WriteLine("---------------------------------------");
            GameInterface.DisplayStats(game);
            int guessAsNumber = GetGuess(game);
            ProcessGuess(game, guessAsNumber);
                
        } while ((game.HasWon, game.IsGameOver) is (false, false));
    }

    private static bool PromptForAnotherGame() {
        Console.WriteLine("---------------------------------------");
        GameInterface.AskForAnotherGame();
        string? response = Console.ReadLine()!.ToLower();
        
        return response.Equals("y");
    }

    private static void ProcessGuess(GameState game, int guess) {
        game.AddAttempt();
        if (game.ChosenRandomNumber == guess) {
            Console.WriteLine("-------------------------------");
            game.HasWon = true;
            GameInterface.PrintCorrectGuessMessage(game);
        }
        else {
            Console.WriteLine("-------------------------------------");
            game.WrongGuess();
            GameInterface.PrintWrongGuessMessage(game);
            if (game.IsGameOver) {
                GameInterface.PrintGameOverMessage(game);
            }
        }
    }

    private static int GetGuess(GameState game) {
        bool isValidGuess;
        int guessAsNumber;
        do {
            Console.WriteLine("---------------------------------------------");
            GameInterface.PromptForGuess(game);
            string? guessAsString = Console.ReadLine();
            isValidGuess = InputValidator.ValidateGuess(guessAsString!, game, out guessAsNumber);
        } while (!isValidGuess);

        return guessAsNumber;
    }

    private static void SetBoundaries(out int lowerBound, out int higherBound) {
        bool areValidBounds;
        do {
            GetBoundaries(out var lowerBoundAsString, out var higherBoundAsString);

            areValidBounds = InputValidator.ValidateBounds(lowerBoundAsString!, higherBoundAsString!,
                out lowerBound, out higherBound);
        } while (!areValidBounds);
    }

    private static void GetBoundaries(out string? lowerBoundAsString, out string? higherBoundAsString) {
        GameInterface.AskForMinimumNumber();
        lowerBoundAsString = Console.ReadLine();
        GameInterface.AskForMaximumNumber();
        higherBoundAsString = Console.ReadLine();
    }
}