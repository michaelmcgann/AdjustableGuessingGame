namespace DiceGame;

public class GameInterface {

    public static void PrintStartingMessage(string message) {
        Console.WriteLine(message);
    }

    public static void PromptForGuess(GameState game) {
        Console.WriteLine($"Guess a number between {game.LowerBoundary} & {game.HigherBoundary}: ");
    }

    public static void DisplayStats(GameState game) {
        Console.WriteLine($"Remaining lives: {game.Lives}. " +
                          $"Lower Bound: {game.LowerBoundary} " +
                          $"Higher Bound: {game.HigherBoundary}");
    }

    public static void PrintWrongGuessMessage(GameState game) {
        Console.WriteLine($"Wrong Number, number of tries remaining: {game.Lives}.");
    }

    public static void PrintCorrectGuessMessage(GameState game) {
        Console.WriteLine($"Correct! Number of attempts: {game.NumberOfAttempts}.");
    }

    public static void PrintGameOverMessage(GameState game) {
        Console.WriteLine($"Uh oh, you have failed to guess the correct number, the number was:" +
                          $" {game.ChosenRandomNumber}.");
    }

    public static void AskForAnotherGame() {
        Console.WriteLine("Do you want to play again? [Y]es or any other key to quit.");
    }

    public static void AskForMinimumNumber() {
        Console.WriteLine("Enter the minimum number you want the random number to be: ");
    }

    public static void AskForMaximumNumber() {
        Console.WriteLine("Enter the maximum number you want the random number to be: ");
    }
    
}