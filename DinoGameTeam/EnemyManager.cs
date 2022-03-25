using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinoGameTeam
{
    internal class EnemyManager
    {
        private List<IDrawable> enemies;
        //private double birdVelocity
        //private double cactiVelocity
        //private double maxBirdVelocity
        //private double maxCactiVelocity

        public EnemyManager()
        {
            //load one of each enemy
            enemies = new List<IDrawable>() { new Cactus("cactus1.dop"), new Cactus("cactus2.dop"), 
            new Cactus("cactus3.dop"), new Bird(17), new Bird(30), new Bird(36)};
        }

        //returns a random enemy from the list
        public IDrawable GetEnemy()
        {
            int random = new Random().Next(enemies.Count);
            IDrawable enemy = enemies[random];
            //updates position back to start
            enemy.X = 210;
            //update enemy velocity based off passed in velocity value 
            enemies.RemoveAt(random);
            return enemy;
        }

        //add enemy back onto the list (when it leaves the screen) so it is never empty
        public void ReceiveEnemy(IDrawable enemy)
        {
            enemies.Add(enemy);
        }

        //public void Update(int score)
        //if not max velocities
        //sets new velocities based on score
    }
}
