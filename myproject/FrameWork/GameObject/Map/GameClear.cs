using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SadSmile
{
    public class GameClear:baseMap
    {

        public GameClear() 
        {
            GenerateMap();
            width = map.GetLength(0);
            height = map.GetLength(1);
        }

        public override char[,] GenerateMap()
        {
            map = new char[1,9]
            {
                  { 'G','A','M','E',' ','C','L','E','R'},
            };
            return map;


        }
    }
}
