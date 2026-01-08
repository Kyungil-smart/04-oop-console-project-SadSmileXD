using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SadSmile
{
    public class TitleScene:Scene
    {
        char[,] maps ;
        public override void Enter()
        {
            maps=new char[20,20];
            for (int i = 0; i < maps.GetLength(0); i++)
            {
                for (int j = 0; j < maps.GetLength(1); j++)
                {
                    maps[i, j] = ' ';
                }
                
            }
            maps[10, 10] = 'P';
        }
        public override void Update()
        {
           
        }
        public override void Exit()
        {

        }
        public override void Render()
        {
          for(int i=0; i<maps.GetLength(0); i++)
            {
                for(int j=0; j< maps.GetLength(1); j++)
                {
                    Console.Write(maps[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
