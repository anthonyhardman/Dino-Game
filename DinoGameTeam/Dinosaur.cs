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
        public Pixel[] Pixels { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private bool isJumping;
        //private double timeSinceJump;
        private double velocity;

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
