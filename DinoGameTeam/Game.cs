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
        public IEnemy[] enemies;
        private bool gameRunning;
        private bool shouldExit;

        double deltaTime = 0.0;
        DateTime lastFrame = DateTime.Now;

        public void Run()
        {
            while (!shouldExit)
            {
                DateTime currentFrame = DateTime.Now;
                deltaTime = (currentFrame - lastFrame).TotalSeconds;
                lastFrame = currentFrame;

                if (gameRunning)
                {
                    foreach (IEnemy enemy in enemies)
                    {
                        enemy.Update(deltaTime);
                    }
                }
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
