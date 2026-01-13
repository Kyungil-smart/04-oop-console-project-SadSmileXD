using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SadSmile
{ 
    public static class MapRenderUtil
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

        public static void PlayerRender(char[,]map,Position pos) =>map[pos.y, pos.x] = 'P';
        public static void GoalRender  (char[,]map,Position pos) =>map[pos.x, pos.y] = 'G';
        public static void BoxRender   (char[,]map,Position pos) =>map[pos.y, pos.x] = 'B';
         
    }
}
