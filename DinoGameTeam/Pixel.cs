using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinoGameTeam
{
    public class Pixel : ConsolePixel
    {
        public int X { get; set; }
        public int Y { get; set; }
        public byte Depth { get; set; }
        public bool UseConsoleBackground { get; set; }
        public override string ToString()
        {
            return $"{TextColor}{BackGroundColor}{Representation}\x1b[0m\u001b[0m";
        }
    }
}
