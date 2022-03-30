namespace DinoGameTeam
{
    public class Program
    {
        public static void Main()
        {
            bool restart = false;
            Game game;

            do
            {
                game = new Game();
                game.Run();

                while (Console.KeyAvailable)
                    Console.ReadKey(true); 
                restart = false;
                while (!restart)
                {
                    if (Console.KeyAvailable)
                    { restart = true; }
                    
                    game.gameOver.Y -= .04;
                    game.window.Draw(game.getDrawableArray());
                }

            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
