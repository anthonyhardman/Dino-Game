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

        public EnemyManager()
        {
            enemies = new List<IDrawable>() { new Cactus("cactus1.dop"), new Cactus("cactus2.dop"), 
            new Cactus("cactus3.dop"), new Bird()};
        }

        public IDrawable GetEnemy()
        {
            int random = new Random().Next(enemies.Count);
            return enemies[random];
        }

        public void ReceiveEnemy(IDrawable enemy)
        {
            enemies.Add(enemy);
        }
    }
}
