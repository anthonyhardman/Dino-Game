using System;
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

        public Game()
        {
            window = new Window(200, 35);
            window.SetClearColor(255, 255, 255);
        }


        public void Run()
        {
            while (!shouldExit)
            {
                DateTime currentFrame = DateTime.Now;
                deltaTime = (currentFrame - lastFrame).TotalSeconds;
                lastFrame = currentFrame;

                if (gameRunning)
                {
                    foreach (IDrawable enemy in enemies)
                    {
                        enemy.Update(deltaTime);
                    }
                }

                window.Draw();
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

        }
    }
}
