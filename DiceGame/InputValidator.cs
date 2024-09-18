namespace DiceGame;

public class InputValidator {

    public static bool ValidateGuess(string guessAsString, GameState game, out int guessAsNumber) {
        
        bool isNumber = int.TryParse(guessAsString, out guessAsNumber);
        if (isNumber && guessAsNumber <= game.HigherBoundary && guessAsNumber >= game.LowerBoundary) {
            return true;
        }

        Console.WriteLine("Input was either not a valid integer or was out of bounds. Try again.");
        return false;
    }

    public static bool ValidateBounds(string lowerBoundAsString, string higherBoundAsString,
        out int lowerBoundAsNumber, out int higherBoundAsNumber) {

        bool isLowerBoundNumber = int.TryParse(lowerBoundAsString, out lowerBoundAsNumber);
        bool isHigherBoundNumber = int.TryParse(higherBoundAsString, out higherBoundAsNumber);

        if (isLowerBoundNumber && isHigherBoundNumber && lowerBoundAsNumber < higherBoundAsNumber) {
            return true;
        }

        Console.WriteLine("bounds need to be valid integers and higher bound needs to be more than lower bound.");
        return false;
    }

    public static bool PlayAgain(string response) {
        string responseLowerCase = response.ToLower();
        
        return responseLowerCase.Equals("y") || responseLowerCase.Equals("yes");
    }
    
}