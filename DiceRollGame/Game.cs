namespace DiceRollGame;

class Game
{
    Player player;
    Dice dice;
    IUserInterface ui;
    int lives;  // number of player's guess before he/ she loses

    public Game(Player player, Dice dice, IUserInterface ui, int lives = 3)
    {
        this.player = player;
        this.dice = dice;
        this.ui = ui;
        this.lives = lives;
    }

    public void Play()
    {
        do
        {
            Run();
        }
        while (WantToReplay());
    }

    bool Run()
    {
        int answer = dice.Roll();

        for (int i = 1; i <= lives; i++)
        {
            int guess = player.Guess(dice.sides);
            if (IsplayersGuessCorrect(guess, answer))
            {
                Win();
                return true;
            }

            if (i != lives)
                ui.write(GuidePlayer(guess, answer));
        }

        Lose();
        return false;
    }

    string GuidePlayer(int guess, int answer)
    {
        if (guess < answer)
            return "too small";
        else
            return "too big";
    }

    bool WantToReplay()
    {
        if (ui is ConsoleUserInterface)
            ui.write("press ENTER to replay");
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.Enter)
                return true;
            return false;
        throw new NotImplementedException();
    }

    bool IsplayersGuessCorrect(int guess, int answer)
    {
        if (guess == answer)
            return true;
        return false;
    }

    void Win()
    {
        ui.write("you won :)");
    }

    void Lose()
    {
        ui.write("you lost :(");
    }
}
