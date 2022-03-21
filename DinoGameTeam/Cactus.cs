using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinoGameTeam
{
    internal class Cactus : IDrawable
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Pixel[] Pixels { get; set; }

        public double Velocity { get; set; } = 50;
        private double Acceleration = 10;

        public Cactus()
        {
            // Feel free to change X, Y, and the 2 parameter of Utils.LoadPixels
            // I was only using these to enusre I completed my stories - Anthony
            X = 184;
            Y = 43;
            Pixels = Utils.LoadPixelsFromFile("resources/cactus/cactus1.dop", '♫', 3);
        }

        public Cactus(string cactusFilePath)
        {
            X = 190;
            Y = 42;

            Pixels = Utils.LoadPixelsFromFile("resources/cactus/" + cactusFilePath, '♫', 3);
        }

        public void Update(double dT)
        {
            X = X - (Velocity * dT + .5 * Acceleration * dT * dT);
        }
    }
}
