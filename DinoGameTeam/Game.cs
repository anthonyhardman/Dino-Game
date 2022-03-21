using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinoGameTeam
{
    internal class Game
    {
        public char[] board;
        public Window window { get; set; }
        public Dinosaur dino { get; set; }
        public List<IDrawable> placeEnemyList;
        public List<int> enemiesToRemove;
        private EnemyManager enemyManager;
        private Ground ground;
        private bool gameRunning = false;
        private bool shouldExit;

        private int test = 0;

        double deltaTime = 0.0;
        DateTime lastFrame = DateTime.Now;

        // Debug delete later----------------------------------------------------------------
        Cactus cactus = new Cactus();
        Bird bird = new Bird();
        Text score = new Text("Score: 0123456789", 0, 0, 0, 0, 0, false, 0, 125, 33, 255);
        Text gameOver = new Text("resources/gameOver/gameover.txt", 72, 15, 255, 0, 0, true);
        Random random = new Random();

        // ----------------------------------------------------------------------------------

        public Game()
        {
            dino = new Dinosaur();
            window = new Window(200, 45);
            ground = new Ground();
            placeEnemyList = new List<IDrawable>();
            enemiesToRemove = new List<int>();
            enemyManager = new EnemyManager();
        }

        public void placeEnemy(IDrawable enemy) // Receive enemies from EnemyManager queue and place them in game.
        {
            placeEnemyList.Add(enemy);
            // Implement code to place enemies.
        }

        public void removeEnemiesFromList()
        {
            foreach (int enemy in enemiesToRemove)
            {
                placeEnemyList.RemoveAt(enemy);
            }
            enemiesToRemove.Clear();
        }

        public void Run()
        {
            Text start = new Text("Press Start", (window._width / 2), (window._height / 2) , 255, 255, 255, false); // Create a new Text() object for start screen.

            while (!shouldExit)
            {
                DateTime currentFrame = DateTime.Now;
                deltaTime = (currentFrame - lastFrame).TotalSeconds;
                lastFrame = currentFrame;


                ProcessInput();

                // Debug delete later----------------------------------------------------------------
                score.UpdateText($"Score: {random.Next()}");
                score.UpdateTextColor(random.Next(255), random.Next(255), random.Next(255));
                score.UpdateBackgroundColor(random.Next(255), random.Next(255), random.Next(255));
                gameOver.UpdateTextColor(random.Next(255), random.Next(255), random.Next(255));
                //gameRunning = true;
                //score.UpdateTextColor(random.Next(255), random.Next(255), random.Next(255));
                //score.UpdateBackgroundColor(random.Next(255), random.Next(255), random.Next(255));
                //gameOver.UpdateTextColor(random.Next(255), random.Next(255), random.Next(255));
                //gameRunning = true;
                // ----------------------------------------------------------------------------------

                if (gameRunning)
                {
                    dino.Update(deltaTime);
                    cactus.Update(deltaTime);
                    bird.Update(deltaTime);
                    ground.Update(deltaTime);

                    // End game if a collision occurs
                    if (CheckCollision())
                    {
                        gameRunning = false;
                    }

                    for (int i = 0; i < placeEnemyList.Count(); i++) // For each enemy in the list...
                    {
                        if (placeEnemyList[i].X <= -16) // If the enemy is done...
                        {
                            enemyManager.ReceiveEnemy(placeEnemyList[i]); // Send enemy to list in EnemyManager
                            enemiesToRemove.Add(i); // Add enemy to remove list
                        }
                    }
                    removeEnemiesFromList();
                    

                    // Debug delete later----------------------------------------------------------------
                    // ----------------------------------------------------------------------------------
                    /*foreach (IDrawable enemy in enemies)
                    {
                        enemy.Update(deltaTime);
                    }*/

                    window.Draw(dino, cactus, bird, score, ground);
                }
                else if (!gameRunning) // Show start screen and wait for key input to start game.
                {
                    window.Draw(start);
                    Console.ReadKey(true);
                    gameRunning = true;
                }
                else
                {
                    //display game over screen if a collision happened
                    Console.Clear();
                    window.Draw(gameOver, score);
                }

                //window.Draw(dino, cactus, bird, score);

                // Debug Fps
                Console.SetCursorPosition(50, 45);
                Console.Write($"{1 / deltaTime}fps");
                Console.SetCursorPosition(0, 45);
                // ---------
            }
        }

        public bool CheckCollision()
        {
            /*//Testing to make sure the display game over works.Can delete. 
            test++;
            if (test == 10)
            {
                return true;
            }
            else
                return false;*/
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

                if (key == ConsoleKey.DownArrow || key == ConsoleKey.S)
                {
                    dino.Duck();
                }
                if (dino.falling && ConsoleKey.DownArrow == key)
                {
                    dino.velocity += 10;
                }
                if (key == ConsoleKey.UpArrow || key == ConsoleKey.W)
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
    }
}
