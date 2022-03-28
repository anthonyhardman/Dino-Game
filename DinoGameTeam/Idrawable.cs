using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinoGameTeam
{
    public interface IDrawable
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Velocity { get; set; }
        public Pixel[] Pixels { get; set; }
        public void Update(double dT);
    }
}
