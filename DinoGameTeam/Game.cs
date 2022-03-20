﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinoGameTeam
{
    internal class Game
    {
        public Window window {get; set;}
        public Dinosaur dino { get; set;}
        public IDrawable[] enemies;
        private bool gameRunning;
        private bool shouldExit;

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
            window.SetClearColor(0, 0, 0);

        }


        public void Run()
        {
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
                gameRunning = true;
                // ----------------------------------------------------------------------------------

                if (gameRunning)
                {

                    dino.Update(deltaTime);
                    // Debug delete later----------------------------------------------------------------
                    bird.Update(deltaTime);
                    // ----------------------------------------------------------------------------------
                    /*foreach (IDrawable enemy in enemies)
                    {
                        enemy.Update(deltaTime);
                    }*/
                }

                window.Draw(dino, cactus, bird, score, gameOver);
            }
        }

        public bool CheckCollision()
        {
            throw new NotImplementedException();
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
                if (key == ConsoleKey.UpArrow || key == ConsoleKey.W) 
                {
                    dino.Jump();
                }
            }
            

            // Clear the input buffer so we don't have odd animation bugs
            while(Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }
                
        }
    }
}
