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
        public double Velocity { get; set; } = 70;
        private double Acceleration = 10;
        private Animation flyingAnimation;

        public Bird()
        {
            int height = new Random().Next(0,3);
            switch (height)
            {
                case 0: Y = 42;
                    break;
                case 1: Y = 17;
                    break;
                case 2: Y = 30;
                    break;
                default: Y = 42;
                    break;
            }
            X = 230;
            flyingAnimation = new Animation(0.1, '¥', "Resources/Bird/flying/birdflying1.dop",
                "Resources/Bird/flying/birdflying2.dop");
        }

        public void Update(double dT)
        {
            flyingAnimation.Update(dT);
            Pixels = flyingAnimation.ActiveFrame;
            X = X - (Velocity * dT + .5 * Acceleration * dT * dT);
        }
    }
}
