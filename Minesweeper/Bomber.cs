using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Mineryder
{
    public class Bomber
    {
        private int bombeTæller;

        public int BombeTæller
        {
            get { return bombeTæller; }
            set { bombeTæller = value; }
        }

        public Bomber() { }

        public byte[,] GenerateBomber(byte[,] plads)
        {
            Random random = new Random();
            bombeTæller = 0;
           int randombombeber = random.Next(0);

            while (bombeTæller < randombombeber)
            {
                int x = random.Next(plads.GetLength(0));
                int y = random.Next(plads.GetLength(1));

                if (plads[x, y] == 0)
                {
                    plads[x, y] = 10;
                    bombeTæller++;
                }
            }
            return plads;
        }
    }
}
