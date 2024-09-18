namespace DiceGame;

public class GameState {

    public int Lives { get; private set; }
    public int LowerBoundary { get; }
    public int HigherBoundary { get; }
    public int NumberOfAttempts { get; private set; }
    public int ChosenRandomNumber { get; private set; }
    public bool HasWon { get; set; }
    public bool IsGameOver { get; private set; }
    private const int DefaultStartingRangeNumber = 0;
    private const int DefaultEndingRangeNumber = 6;

    public GameState() : this(DefaultStartingRangeNumber, 
        DefaultEndingRangeNumber) {
    }

    public GameState(int lowerBoundary, int higherBoundary) {
        LowerBoundary = lowerBoundary;
        HigherBoundary = higherBoundary;
        ChosenRandomNumber = RandomNumber.GetRandomNumber(lowerBoundary, higherBoundary);
        CalculateStartingLives();
        HasWon = false;
        IsGameOver = false;
        NumberOfAttempts = 0;
    }

    private void CalculateStartingLives() {
        Lives = (1 + HigherBoundary - LowerBoundary) / 2; 
    }

    public void WrongGuess() {
        Lives--;
        if (Lives < 1) {
            IsGameOver = true;
        }
    }

    public void AddAttempt() {
        NumberOfAttempts++;
    }
    
}