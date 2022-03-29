namespace DinoGameTeam
{
    public class Program
    {
        public static void Main()
        {
            Game game;

            do
            {
                game = new Game();
                game.Run();

                while (Console.KeyAvailable)
                    Console.ReadKey(true);
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
