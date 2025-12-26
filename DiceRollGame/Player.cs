namespace DiceRollGame;

class Player
{
    public IUserInterface ui;

    public Player(IUserInterface ui)
        => this.ui = ui;

    public int Guess(int range) // range is Dice.sides
    {
        do
        {
            string input = ui.read("what is your guess?");
            if (int.TryParse(input, out int guess) && 1 <= guess && guess <= range)
                return guess;
            ui.write("invalid input, try again");
        }
        while (true);
    }
}