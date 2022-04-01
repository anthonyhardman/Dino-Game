using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinoGameTeam
{
    public class EnemyManager
    {
        private List<IDrawable> enemies;
        private double enemyVelocity;
        private double maxVelocity;
        private double acceleration;
        int scoreBound;

        public EnemyManager()
        {
            enemyVelocity = 80;
            maxVelocity = 260;
            acceleration = 20;
            scoreBound = 100;

            //load one of each enemy
            enemies = new List<IDrawable>() { new Cactus("cactusH.dop"), new Cactus("cactusM.dop"), 
            new Cactus("cactusS.dop"), new Cactus("cactusCluster1.dop"), new Cactus("cactusCluster2.dop"),
            new Cactus("cactusCluster3.dop"), new Cactus("cactusClusterH2W.dop"), new Cactus("cactusClusterM2W.dop"),
            new Cactus("cactusClusterS2W.dop"), new Cactus("cactusClusterM3W.dop"), new Cactus("cactusClusterS3W.dop"),
            new Bird(17), new Bird(30), new Bird(36), new Bird(43)};
        }

        //returns a random enemy from the list
        public IDrawable GetEnemy()
        {
            int random = new Random().Next(enemies.Count);
            IDrawable enemy = enemies[random];
            //updates position back to start
            enemy.X = 210;
            //update enemy velocity based off passed in velocity value 
            enemy.Velocity = enemyVelocity;
            enemies.RemoveAt(random);
            return enemy;
        }

        //add enemy back onto the list (when it leaves the screen) so it is never empty
        public void ReceiveEnemy(IDrawable enemy)
        {
            enemies.Add(enemy);
        }


        public void Update(int score)
        {
            //set bounds for when the velocity increases

            //increases velocity if next score section is met
            while (score >= scoreBound)
            {
                //increase only if not max velocity
                if (enemyVelocity != maxVelocity)
                {
                    enemyVelocity += acceleration;
                }
                //set next increment section
                scoreBound += 100;
            }

        }
    }
}
