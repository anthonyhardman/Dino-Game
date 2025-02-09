﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinoGameTeam
{
    public class Cactus : IDrawable
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Pixel[] Pixels { get; set; }

        public double Velocity { get; set; }

        public Cactus(string cactusFilePath)
        {
            X = 190;
            Y = 43;

            //get cactus .dop file image
            Pixels = Utils.LoadPixelsFromFile("resources/cactus/" + cactusFilePath, '♫', 3);
        }

        public void Update(double dT)
        {
            //move cactus (kinematic equation)
            X = X - (Velocity * dT);
        }
    }
}
