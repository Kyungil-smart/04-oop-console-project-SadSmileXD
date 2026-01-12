using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SadSmile
{ 
    public static class MathFExtensions
    {
        public static int Clamp(this int value,int min,int max)
        {
            if (value > max) return max;
            if (value < min) return min;

            return value;
        }
    }
}
