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
        private Animation flyingAnimation;

        public Bird()
        {
            // Feel free to change X, Y, and the 2 parameter of Utils.LoadPixels
            // I was only using these to enusre I completed my stories - Anthony
            X = 100;
            Y = 17;
            flyingAnimation = new Animation(0.1, '¥', "Resources/Bird/flying/birdflying1.dop",
                "Resources/Bird/flying/birdflying2.dop");
        }

        public void Update(double dT)
        {
            flyingAnimation.Update(dT);
            Pixels = flyingAnimation.ActiveFrame;
        }
    }
}
