﻿using System;
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
        private Ground ground;
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
            ground = new Ground(window._width);

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
                //score.UpdateTextColor(random.Next(255), random.Next(255), random.Next(255));
                //score.UpdateBackgroundColor(random.Next(255), random.Next(255), random.Next(255));
                //gameOver.UpdateTextColor(random.Next(255), random.Next(255), random.Next(255));
                gameRunning = true;
                // ----------------------------------------------------------------------------------

                if (gameRunning)
                {
                    ground.Update();
                    dino.Update(deltaTime);
                    // Debug delete later----------------------------------------------------------------
                    bird.Update(deltaTime);
                    // ----------------------------------------------------------------------------------
                    /*foreach (IDrawable enemy in enemies)
                    {
                        enemy.Update(deltaTime);
                    }*/
                }

                window.Draw(dino, cactus, bird, score);

                // Debug Fps
                Console.SetCursorPosition(50, 45);
                Console.Write($"{1 / deltaTime}fps");
                Console.SetCursorPosition(0, 45);
                // ---------
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
