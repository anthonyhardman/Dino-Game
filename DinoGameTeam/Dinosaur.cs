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
        public double Velocity { get; set; }
        public Pixel[] Pixels { get; set; }

        public bool isJumping;
        public bool falling;
        private int maxHeight;
        public bool isDucking;
        private double timeSinceJump = 0;
        //public double Velocity; 
        private Animation walkAnimation;
        private Animation duckAnimation;
        private double timeDucking = 0;

        private double acceleration = 200;
        private double worldZero = 43;
        private double boostedVelocity = 0;

        public Dinosaur()
        {
            X = 0;
            Y = worldZero;
            Velocity = 30;
            Pixels = Utils.LoadPixelsFromFile("resources/dino/dino.dop", '♥', 1);

            walkAnimation = new Animation(0.1, '♥', "resources/dino/walking/walk1.dop",
                "resources/dino/walking/walk2.dop");

            duckAnimation = new Animation(0.1, '♥', "resources/dino/ducking/walk1.dop",
                "resources/dino/ducking/walk2.dop");
        }

        public void Update(double dT)
        {

            if (isJumping)
            {
                Y += (0.25 * acceleration * dT * dT) + (Velocity * dT);
                if (Y < 16)
                {
                    Velocity = 0;
                    Y = 16;
                }
                if (Y >= worldZero)
                {
                    Y = worldZero;
                    isJumping = false;
                    boostedVelocity = 0;
                }
                Velocity += acceleration * dT;
            }
            if (isDucking)
            {
                timeDucking += dT;
                duckAnimation.Update(dT);
                Pixels = duckAnimation.ActiveFrame;
                if (timeDucking > 1.0 || isJumping)
                {
                    isDucking = false;
                    timeDucking = 0;
                }
            }
            else
            {
                walkAnimation.Update(dT);
                Pixels = walkAnimation.ActiveFrame;
            }
        }

        public void Jump()
        {
            if (!isJumping)
            {
                Velocity = -90.0;
            }
            else if (boostedVelocity >= -40.0)
            {
                Velocity -= 8.0;
                boostedVelocity -= 8.0;

                if (boostedVelocity <= 40.0)
                {
                    int x = 0;
                }
            }
            isJumping = true;
        }

        public void Duck()
        {
            if (!isJumping)
            {
                isDucking = true;
            }
            if (isDucking)
            {
                timeDucking = 0;
            }
        }
    }
}
