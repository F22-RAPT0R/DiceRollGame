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

    public void Run()
    {
        do
        {
            Play();
        }
        while (WantToReplay());
    }

    bool Play()
    {
        int answer = dice.Roll();

        for (int i = 1; i <= lives; i++)
        {
            int guess = player.Guess(dice.sides);
            if (IsplayerGuessCorrect(guess, answer))
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
        => guess < answer ? "too small" : "too big";

    bool WantToReplay()
    {
        if (ui is ConsoleUserInterface)
            ui.write("press ENTER to replay");
            var key = Console.ReadKey();
            return key.Key == ConsoleKey.Enter;
        throw new NotImplementedException();
    }

    bool IsplayerGuessCorrect(int guess, int answer)
        => guess == answer;

    void Win()
        => ui.write("you won :)");

    void Lose()
        => ui.write("you lost :(");
}
