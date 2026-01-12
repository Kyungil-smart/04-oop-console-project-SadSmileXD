using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SadSmile
{
    public class baseMap  
    {
        public char[,] map;
        public int width = 0;
        public int height = 0;

        public baseMap()
        {
          
        }
        public virtual char[,] GenerateMap()
        {

            return null;
        }

        
    }
}
