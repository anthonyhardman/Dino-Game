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
        private bool down;
        public bool isDucking;
        private double timeSinceJump = 0;
        private double velocity;
        private Animation walkAnimation;
        private Animation duckAnimation;
        private double timeDucking = 0;

        public Dinosaur()
        {
            // Feel free to change X, Y, and the 2 parameter of Utils.LoadPixels
            // I was only using these to enusre I completed my stories - Anthony
            X = 0;
            Y = 35;
            Pixels = Utils.LoadPixelsFromFile("resources/dino/dino.dop", '♥', 1);

            walkAnimation = new Animation(0.1, '♥', "resources/dino/walking/walk1.dop",
                "resources/dino/walking/walk2.dop");

            duckAnimation = new Animation(0.1, '♥', "resources/dino/ducking/walk1.dop",
                "resources/dino/ducking/walk2.dop");
        }

        public void Update(double dT)
        {
            if (isJumping && isDucking == false)
            {
                if (down==true)
                {
                    if (timeSinceJump == 0)
                    { 
                        down = false;
                        isJumping = false;
                    }
                    else 
                    {
                        Y +=2;
                        timeSinceJump--;
                    }

                }
                else if(down==false)
                { 
                    timeSinceJump++;
                    Y -= 2;
                    if (timeSinceJump >= 9)
                    {
                        down=true;
                    }

                }

                
            }
            else if (isDucking && isJumping==false)
            {
                timeDucking += dT;
                duckAnimation.Update(dT);
                Pixels = duckAnimation.ActiveFrame;
                if (timeDucking > 0.4)
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
        }

        public void Duck()
        {
            if (!isJumping)
            {
                isDucking = true;
            }
        }
    }
}
