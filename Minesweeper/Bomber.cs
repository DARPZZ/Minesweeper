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
        public Bomber() { }

         Random random = new Random();
        /*
         * Generer 10 forskellige bomber der er random placeret
         */
        public byte[,] GenerateBomber(byte[,] plads)
        {
            Random random = new Random();

            int bombetæller = 0;
           int randombombeber = random.Next(10, 40);

            while (bombetæller < randombombeber)
            {
                int x = random.Next(plads.GetLength(0));
                int y = random.Next(plads.GetLength(1));

                if (plads[x, y] == 0)
                {
                    plads[x, y] = 10;
                    bombetæller++;
                }
            }
            Debug.WriteLine(bombetæller + ": bombetæller");
            return plads;
        }
    }
}
