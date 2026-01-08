using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SadSmile
{
    struct Vector2
    {
        public int x;
        public int y;

        public Vector2(int x,int y)
        {
            this.x = x; 
            this.y = y;
        }
        public static Vector2 Up   => new Vector2(0, -1);
        public static Vector2 Down => new Vector2(0, 1);
        public static Vector2 Left => new Vector2(-1, 0);
        public static Vector2 Right=> new Vector2(1, 0);

        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            return new Vector2(
                a.x + b.x, 
                a.y + b.y
                );
        }
        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            return new Vector2(
                a.x - b.x,
                a.y - b.y
                );
        }

    }
      
}
 
