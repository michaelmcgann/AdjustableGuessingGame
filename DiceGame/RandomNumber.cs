namespace DiceGame;

public class RandomNumber {

    private static readonly Random Random = new Random();
    
    /// <summary>
    /// Generates a random integer between two given integers.
    /// </summary>
    /// <param name="startRange">Integer in which the range will start, inclusive.</param>
    /// <param name="endRange">Integer in which range will end, inclusive.</param>
    /// <returns>integer between given parameters, inclusively.</returns>
    public static int GetRandomNumber(int startRange, int endRange) {
        return Random.Next(startRange, endRange + 1);
    }
    
}