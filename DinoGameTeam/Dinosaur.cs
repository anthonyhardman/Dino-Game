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
        public bool falling;
        private int maxHeight;
        public bool isDucking;
        private double timeSinceJump = 0;
        public double velocity;
        private Animation walkAnimation;
        private Animation duckAnimation;
        private double timeDucking = 0;

        public Dinosaur()
        {
            // Feel free to change X, Y, and the 2 parameter of Utils.LoadPixels
            // I was only using these to enusre I completed my stories - Anthony
            X = 0;
            Y = 42;
            velocity = 20;
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
                int groundHeight = 43;
                if (falling)
                {
                    if (Y + (velocity * dT) > groundHeight)
                    {
                        falling = false;
                        isJumping = false;
                        velocity = 20;
                        Y = groundHeight;
                    }
                    else
                    {
                        Y = Y + (velocity * dT);
                        timeSinceJump--;
                    }

                }
                else if (!falling)
                {
                    timeSinceJump += dT;
                    Y = Y + (-velocity * dT);
                    if (timeSinceJump > 0.3)
                    {
                        maxHeight = 20;
                    }
                    else
                    {
                        maxHeight = 18;
                    }
                    if (Y + (-velocity * dT) < maxHeight)
                    {
                        falling = true;
                    }

                }


            }
            if (isDucking)
            {
                timeDucking += dT;
                duckAnimation.Update(dT);
                Pixels = duckAnimation.ActiveFrame;
                if (timeDucking > 0.1 || isJumping)
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
            isJumping = true;
            //isDucking = false;
        }

        public void Duck()
        {
            if (!isJumping)
            {
                isDucking = true;
                timeDucking = 0;
            }
        }
    }
}
