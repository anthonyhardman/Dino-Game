using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinoGameTeam
{
    internal class Bird : IDrawable, IEnemy
    {
        public double X { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double Y { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Pixel[] Pixels { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double Velocity { get; set; }

        public void Update(double dT)
        {

        }
    }
}
