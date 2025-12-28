namespace DiceRollGame.UserInterface;

public interface IUserInterface
{
    void write(string message = "");
    string? read(string message = "");
}
