namespace DinoGameTeam
{
    public class Program
    {
        public static void Main()
        {
            bool restart = false;
            bool quit = false;
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
                    {
                        ConsoleKey key = Console.ReadKey().Key;
                        if (key == ConsoleKey.R)
                        {
                            restart = true; 
                        }
                        else if (key == ConsoleKey.Escape)
                        {
                            quit = true;
                            break;
                        }
                    }
                    
                    game.gameOver.Y -= .04;
                    game.window.Draw(game.getDrawableArray());
                }

            }
            while (!quit);
        }
    }
}
