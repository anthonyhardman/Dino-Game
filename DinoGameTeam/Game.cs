using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinoGameTeam
{
    internal class Game
    {
        private Window window { get; set; }
        private Dinosaur dino { get; set; }
        private List<IDrawable> enemiesOnScreen;
        private List<int> enemiesToRemove;
        private EnemyManager enemyManager;
        private Ground ground;
        private DateTime beginningTime;
        private GameState state;
        private double timeSinceEnemyPlaced=0;
        private double enemyFrequency=2;
        private double deltaTime = 0.0;
        private DateTime lastFrame= DateTime.Now;
        private Text start = new Text("Press Start", (200 / 2), (45 / 2), 255, 255, 255, false); // Create a new Text() object for start screen.
        private Text score = new Text("Score: 0123456789", 0, 0, 0, 0, 0, false, 0, 125, 33, 255);
        private Text gameOver = new Text("resources/gameOver/gameover.txt", 72, 15, 255, 0, 0, true);
        

        public Game()
        {
            state = GameState.NOTRUNNING;
            dino = new Dinosaur();
            window = new Window(200, 45);
            ground = new Ground();
            enemiesOnScreen = new List<IDrawable>();
            enemiesToRemove = new List<int>();
            enemyManager = new EnemyManager();
        }

        public void Run()
        {
            //test, Garrett can delete when placing enemies is implemented.

            while (state != GameState.EXIT)
            {
                DateTime currentFrame = DateTime.Now;
                deltaTime = (currentFrame - lastFrame).TotalSeconds;
                lastFrame = currentFrame;

                ProcessInput();

                if (state == GameState.RUNNING)
                {
                    placeEnemy();
                    //PUT ENEMY IN
                    dino.Update(deltaTime);
                    foreach (IDrawable enemy in enemiesOnScreen)
                    {
                        enemy.Update(deltaTime);
                    }
                    ground.Update(deltaTime);
                    score.UpdateText($"Score: {(int)(10 * (DateTime.Now - beginningTime).TotalSeconds)}");

                    // End game if a collision occurs
                    if (CheckCollision())
                    {
                        state = GameState.GAMEOVER;
                    }

                    for (int i = 0; i < enemiesOnScreen.Count(); i++) // For each enemy in the list...
                    {
                        if (enemiesOnScreen[i].X <= -16) // If the enemy is done...
                        {
                            enemyManager.ReceiveEnemy(enemiesOnScreen[i]); // Send enemy to list in EnemyManager
                            enemiesToRemove.Add(i); // Add enemy to remove list
                        }
                    }
                    removeEnemiesFromList();
                }
                
                window.Draw(getDrawableArray());

                // Debug Fps
                Console.SetCursorPosition(50, 45);
                Console.Write($"{Math.Round(1 / deltaTime, 2)}fps");
                Console.SetCursorPosition(0, 45);
                // ---------
            }
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
                    //iterate over dino's pixels
                    for (int i = 0; i < dino.Pixels.Length; i++) 
                    {
                        for (int j = 0; j < enemy.Pixels.Length; j++)
                        {
                            if ((dino.Pixels[i].X + (int)dino.X) == (enemy.Pixels[j].X + (int)enemy.X) && (dino.Pixels[i].Y + (int)dino.Y) == (enemy.Pixels[j].Y + (int)enemy.Y))
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;

        }

        public void Reset()
        {

        }

        public void ProcessInput()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey().Key;

                if (state == GameState.NOTRUNNING)
                {
                    beginningTime = DateTime.Now;
                    state = GameState.RUNNING;
                }
                else if ((key == ConsoleKey.DownArrow || key == ConsoleKey.S) && !dino.falling )
                {
                    dino.Duck();
                }
                else if (dino.falling && (ConsoleKey.DownArrow == key || ConsoleKey.S == key))
                {
                    dino.velocity += 10;
                }
                else if (key == ConsoleKey.UpArrow || key == ConsoleKey.W || key == ConsoleKey.Spacebar)
                {
                    dino.Jump();
                }
            }

            // Clear the input buffer so we don't have odd animation bugs
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }

        }

        public IDrawable[] getDrawableArray()
        {
            List<IDrawable> drawArray = new List<IDrawable>();

            if (state == GameState.NOTRUNNING)
            {
                drawArray.Add(start);
            }
            else if (state == GameState.RUNNING)
            {
                foreach (IDrawable enemy in enemiesOnScreen)
                {
                    drawArray.Add(enemy);
                }
                drawArray.Add(dino);
                drawArray.Add(score);
                drawArray.Add(ground);
            }
            else if (state == GameState.GAMEOVER)
            {
                score.X = 95;
                score.Y = 21;
                drawArray.Add(score);
                drawArray.Add(gameOver);
            }

            return drawArray.ToArray();
        }
    }
}
