using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinoGameTeam
{
    public class Dinosaur : IDrawable
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Pixel[] Pixels { get; set; }

        private bool isJumping;
        //private double timeSinceJump;
        private double velocity;

        public Dinosaur()
        {
            // Feel free to change X, Y, and the 2 parameter of Utils.LoadPixels
            // I was only using these to enusre I completed my stories - Anthony
            X = 0;
            Y = 35;
            Pixels = Utils.LoadPixelsFromFile("resources/dino/dino.dop", '♥', 1);
        }

        public void Update(double dT)
        {

        }

        public void Jump()
        {

        }

        public void Duck()
        {

        }
    }
}
