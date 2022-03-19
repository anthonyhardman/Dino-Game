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

        public double Velocity { get; set; }

        public Cactus()
        {
            // Feel free to change X, Y, and the 2 parameter of Utils.LoadPixels
            // I was only using these to enusre I completed my stories - Anthony
            X = 184;
            Y = 35;
            Pixels = Utils.LoadPixelsFromFile("resources/cactus/cactus1.dop", '♫', 3);
        }

        public void Update(double dT)
        {

        }
    }
}
