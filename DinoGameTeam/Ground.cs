using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinoGameTeam
{
    internal class Ground
    {
        private char[] ground0;
        private char[] ground1;
        string groundSet = "-";
        int activeSet = 0;
        public Ground(int width)
        {
            ground0 = new char[width];
            ground1 = new char[width];
            for (int i = 0; i < ground0.Length; i++) 
            {
                if (i % 2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    ground1[i] = groundSet[0];
                }
                else
                { 
                    Console.ForegroundColor= ConsoleColor.DarkMagenta;
                    ground1[1] = groundSet[0];
                }
                if (i % 2 == 1)
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    ground0[i] = groundSet[0];
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    ground0[i] = groundSet[0];
                }
            }
        }

        public void Update()
        {
            Console.SetCursorPosition(0, 35);
            if (activeSet == 0)
            {
                Console.WriteLine(ground1);
                activeSet = 1;
            }
            else 
            {
                Console.WriteLine(ground0);
                activeSet = 0;
            }
        }
    }
}
