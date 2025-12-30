namespace DiceRollGame;

class Program
{
    static void Main(string[] args)
    {
        IUserInterface ui = new ConsoleUserInterface();
        Player player = new(ui);
        Dice dice = new(6);
        int lives = 3;
        Game game = new(player, dice, ui, lives);
        game.Run();
    }
}
