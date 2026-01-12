using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SadSmile
{ 
    public static class MapRender
    {
        public static void Render(char[,]maps)
        {
            for (int i = 0; i < maps.GetLength(0); i++)
            {
                for (int j = 0; j < maps.GetLength(1); j++)
                {
                    Console.Write(maps[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
