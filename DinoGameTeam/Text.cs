using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinoGameTeam
{
    public class Text : IDrawable
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Velocity { get; set; }    //not used
        public Pixel[] Pixels { get; set; }

        private (int r, int g, int b) _color;
        private (int r, int g, int b) _backgroundColor;
        private byte _depth;

        public Text(string textOrFile, double x, double y, int frontR, int frontG, int frontB, bool file = false, byte depth = 0, int backR = -1, int backG = -1, int backB = -1)
        {
            _color = (frontR, frontG, frontB);
            _backgroundColor = (backR, backG, backB);
            _depth = depth;

            X = x;
            Y = y;
            if (file)
            {
                Pixels = Utils.LoadPixelsFromFile(textOrFile, frontR, frontG, frontB, depth, backR, backG, backB);
            }
            else
            {
                Pixels = Utils.LoadPixelsFromString(textOrFile, frontR, frontG, frontB, depth, backR, backG, backB);
            }
        }
        //Is only used for the credits to scroll up.
        public void Update(double dT)
        {
           
        }

        public void UpdateText(string textOrFile, bool file = false)
        {
            if (file)
            {
                Pixels = Utils.LoadPixelsFromFile(textOrFile, _color.r, _color.g, _color.b, _depth, _backgroundColor.r, _backgroundColor.g, _backgroundColor.b);
            }
            else
            {
                Pixels = Utils.LoadPixelsFromString(textOrFile, _color.r, _color.g, _color.b, _depth, _backgroundColor.r, _backgroundColor.g, _backgroundColor.b);
            }
        }

        public void UpdateTextColor(int r, int g, int b)
        {
            _color = (r, g, b);

            foreach (Pixel pixel in Pixels)
            {
                pixel.TextColor = Utils.RGBtoTextColor(r, g, b);
            }
        }

        public void UpdateBackgroundColor(int r, int g, int b)
        {
            _backgroundColor = (r, g, b);

            foreach (Pixel pixel in Pixels)
            {
                pixel.UseConsoleBackground = false;
                pixel.BackGroundColor = Utils.RGBtoBackgroundColor(r, g, b);
            }
        }
    }
}
