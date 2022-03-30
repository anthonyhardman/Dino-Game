

namespace DinoGameTeam
{
    public class Game
    {
        public Window window { get; set; }
        private Dinosaur dino { get; set; }
        private List<IDrawable> enemiesOnScreen;
        private List<int> enemiesToRemove;
        private EnemyManager enemyManager;
        private Ground ground;
        private DateTime beginningTime;
        private GameState state;
        private double timeSinceEnemyPlaced = 0;
        private double enemyFrequency = 2;
        private double deltaTime = 0.0;
        private DateTime lastFrame= DateTime.Now;
        private Text start;
        public Text scoreText = new Text("Score: 0123456789", 0, 0, 0, 0, 0, false, 0, 125, 33, 255);
        public Text gameOver = new Text("resources/gameOver/gameover.txt", 72, 15, 255, 0, 0, true);
        private int score;
        

        //constructor
        public Game()
        {
            state = GameState.NOTRUNNING;
            dino = new Dinosaur();
            window = new Window(200, 45);
            start = new Text("resources/Instructions/Instructions.txt", window._width/2.75, window._height/2.5, 255, 100, 255, true); // Creates a new Text() object for start screen.
            ground = new Ground();
            enemiesOnScreen = new List<IDrawable>();
            enemiesToRemove = new List<int>();
            enemyManager = new EnemyManager();
        }

        //Runs the game
        public void Run()
        {
            while (state != GameState.EXIT)
            {
                DateTime currentFrame = DateTime.Now;
                deltaTime = (currentFrame - lastFrame).TotalSeconds;
                lastFrame = currentFrame;

                //check user input (jump, duck, etc)
                ProcessInput();

                //playing game
                if (state == GameState.RUNNING)
                {
                    //places enemy
                    placeEnemy();
                    //moves dino
                    dino.Update(deltaTime);
                    //moves all enemies
                    foreach (IDrawable enemy in enemiesOnScreen)
                    {
                        enemy.Update(deltaTime);
                    }

                    //moves ground
                    ground.Update(deltaTime);
                    score = (int)(10 * (DateTime.Now - beginningTime).TotalSeconds);

                    //update scoreText value
                    scoreText.UpdateText($"Score: {score}");

                    // Updates score background color every 500pts.
                    if (score != 0 && score % 500 == 0)
                    {
                        // Gets a new color.
                        Tuple<int, int, int> color = colorRNG();

                        // Updates background color for score.
                        scoreText.UpdateBackgroundColor(color.Item1, color.Item2, color.Item3);
                    }
                    

                    enemyManager.Update(score);

                    // End game if a collision occurs
                    if (CheckCollision())
                    {
                        state = GameState.GAMEOVER;
                    }

                    for (int i = 0; i < enemiesOnScreen.Count(); i++) // For each enemy in the list...
                    {
                        if (enemiesOnScreen[i].X <= -48) // If the enemy is done...
                        {
                            enemyManager.ReceiveEnemy(enemiesOnScreen[i]); // Send enemy to list in EnemyManager
                            enemiesToRemove.Add(i); // Add enemy to remove list
                        }
                    }
                    removeEnemiesFromList();
                }
                
                //draws game screen
                window.Draw(getDrawableArray());

                // Debug Fps
                Console.SetCursorPosition(50, 45);
                Console.Write($"{Math.Round(1 / deltaTime, 2)}fps");
                Console.SetCursorPosition(0, 45);
                // ---------
            }
        }

        // Generates three random integers between 0 and 255.
        public Tuple<int, int, int> colorRNG()
        {
            Random rng = new Random();
            int[] array = new int[3];

            // Limits how dark the pixel can be.
            int colorLimit = 128;

            // Stores a random integer for r, g, and b.
            for (int i = 0; i < 3; i++)
            {
                array[i] = rng.Next(255);
            }

            // Determines if color selected is bright enough and redoes operation if necessary.
            for (int i = 0; i < 3; i++)
            {
                int j = i + 1;

                if (j == 3)
                {
                    j = 0;
                }

                while (array[i] < colorLimit && array[j] < colorLimit)
                {
                    array[i] = rng.Next(255);
                }
            }

            // Returns r, g, and b as a tuple.
            return new Tuple<int, int, int>(array[0], array[1], array[2]);
        }

        public void placeEnemy() // Receive enemies from EnemyManager queue and place them in game.
        {

            if (timeSinceEnemyPlaced >= enemyFrequency)
            {
                enemiesOnScreen.Add(enemyManager.GetEnemy());
                timeSinceEnemyPlaced = 0;
            }
            else
            {
                timeSinceEnemyPlaced += deltaTime;
            }
            

        }

        public void removeEnemiesFromList()
        {
            foreach (int enemy in enemiesToRemove)
            {
                enemiesOnScreen.RemoveAt(enemy);
            }
            enemiesToRemove.Clear();
        }

        public bool CheckCollision()
        {
            foreach (IDrawable enemy in enemiesOnScreen) 
            {
                if (enemy.X < 40)
                {
                    if (CheckCollision(dino, enemy))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool CheckCollision(IDrawable dino, IDrawable enemy)
        {
            foreach (Pixel dPixel in dino.Pixels)
            {
                foreach(Pixel ePixel in enemy.Pixels)
                {
                    if (dPixel.X + (int)dino.X == ePixel.X + (int)enemy.X && dPixel.Y + (int)dino.Y == ePixel.Y + (int)enemy.Y)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public void ProcessInput()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey().Key;

                //start game
                if (state == GameState.NOTRUNNING)
                {
                    beginningTime = DateTime.Now;
                    state = GameState.RUNNING;
                }
                //duck
                else if ((key == ConsoleKey.DownArrow || key == ConsoleKey.S) && !dino.isJumping )
                {
                    dino.Duck();
                }
                //fall faster
                else if (dino.isJumping && (ConsoleKey.DownArrow == key || ConsoleKey.S == key))
                {
                    dino.Velocity += 75;
                }
                //jump
                else if (key == ConsoleKey.UpArrow || key == ConsoleKey.W || key == ConsoleKey.Spacebar)
                {
                    dino.Jump();
                }

                // Clear the input buffer so we don't have odd animation bugs
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }
            }
        }

        public IDrawable[] getDrawableArray()
        {
            List<IDrawable> drawArray = new List<IDrawable>();

            //display start screen
            if (state == GameState.NOTRUNNING)
            {
                drawArray.Add(start);
            }
            //display game
            else if (state == GameState.RUNNING)
            {
                //draws enemies
                foreach (IDrawable enemy in enemiesOnScreen)
                {
                    drawArray.Add(enemy);
                }
                drawArray.Add(dino);
                drawArray.Add(scoreText);
                drawArray.Add(ground);
            }
            //display game over
            else if (state == GameState.GAMEOVER)
            {
                scoreText.X = 0;
                scoreText.Y = 0;
                drawArray.Add(scoreText);
                drawArray.Add(gameOver);
                state = GameState.EXIT;
            }
            else if (state==GameState.EXIT)
            {

                drawArray.Add(scoreText);
                drawArray.Add(gameOver);
            }

            //returns an array to be passed into window.Draw()
            return drawArray.ToArray();
        }
    }
}
