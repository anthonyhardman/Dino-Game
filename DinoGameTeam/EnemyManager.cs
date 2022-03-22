﻿using System;
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
            new Cactus("cactus3.dop"), new Bird(17), new Bird(30), new Bird(36)};
        }

        public IDrawable GetEnemy()
        {
            int random = new Random().Next(enemies.Count);
            IDrawable enemy = enemies[random];
            enemies.RemoveAt(random);
            return enemy;
        }

        public void ReceiveEnemy(IDrawable enemy)
        {
            enemy.X = 210;
            enemies.Add(enemy);
        }
    }
}
