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

        private bool isJumping;
        public bool falling;
        private int maxHeight;
        public bool isDucking;
        private double timeSinceJump = 0;
        //public double Velocity; 
        private Animation walkAnimation;
        private Animation duckAnimation;
        private double timeDucking = 0;

        public Dinosaur()
        {
            X = 0;
            Y = 43;
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
                int groundHeight = 43;
                if (falling)
                {
                    if (Y + (Velocity * dT) > groundHeight)
                    {
                        falling = false;
                        isJumping = false;
                        Velocity = 30;
                        Y = groundHeight;
                    }
                    else
                    {
                        Y = Y + (Velocity * dT);
                        timeSinceJump--;
                    }

                }
                else if (!falling)
                {
                    // this was early attempts to implement the max jump height
                    // doesn't work because is based on time since jump which i used for the dino to come back down
                    // need to based maxheight on something other then time since jumped.
                    timeSinceJump += dT;
                    Y = Y + (-Velocity * dT);
                    if (timeSinceJump > 0.3)
                    {
                        maxHeight = 20;
                    }
                    else
                    {
                        maxHeight = 18;
                    }
                    if (Y + (-Velocity * dT) < maxHeight)
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
            isJumping = true;
            //isDucking = false;
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
