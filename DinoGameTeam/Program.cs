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
<<<<<<< HEAD
                    while (Console.KeyAvailable)
                        Console.ReadKey(true);
=======
                while (Console.KeyAvailable)
                    Console.ReadKey(true); 
>>>>>>> 37c7e7c55af9cadd63e99e3dde136fb98e43dcdb
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
