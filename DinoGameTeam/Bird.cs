using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinoGameTeam
{
    internal class Bird : IDrawable
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Pixel[] Pixels { get; set; }
        public double Velocity { get; set; }

        public Bird()
        {
            // Feel free to change X, Y, and the 2 parameter of Utils.LoadPixels
            // I was only using these to enusre I completed my stories - Anthony
            X = 100;
            Y = 17;
            Pixels = Utils.LoadPixelsFromFile("resources/bird/bird.dop", '¥', 2);
        }

        public void Update(double dT)
        {

        }
    }
}
