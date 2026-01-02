namespace DiceRollGame;

class Dice
{
    public int sides {  get; set; }

    public Dice(int sides=6)
        => this.sides = sides;

    public int Roll()
    {
        var random = new Random();
        return random.Next(1, sides + 1);
    }
}
