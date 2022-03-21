using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinoGameTeam
{
    internal class Ground : IDrawable
    {

        public Ground()
        {
            X = 0;
            Y = 43;
            Pixels = Utils.LoadPixelsFromFile("resources/ground/ground.txt", 255, 255, 255, 0);
        }

        public double X { get; set; }
        public double Y { get; set; }
        public Pixel[] Pixels { get; set; }

        

        public void Update(double dT)
        {
            if (X == -5)
            {
                X = 0;
            }
            else
            {
                X--;
            }
        }
    }
}
