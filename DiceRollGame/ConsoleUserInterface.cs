namespace DiceRollGame;

public class ConsoleUserInterface : IUserInterface
{
    public void write(string message = "")
        => Console.WriteLine(message);

    public string? read(string message = "")
    {
        write(message);
        return Console.ReadLine();
    }
}
