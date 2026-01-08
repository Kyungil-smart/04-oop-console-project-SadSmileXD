using System;
using System.Collections.Generic;
using System.Data;
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

            draw();
        }
        public void draw()
        {
            for (int i = 0; i < maps.GetLength(0); i++)
            {
                for (int j = 0; j < maps.GetLength(1); j++)
                {
                    maps[i, j] = ' ';
                }

            }
            var pos = PlayerManager.Instance.move.position;
            maps[pos.y, pos.x] = 'P';
            maps[maps.GetLength(0) - 1, maps.GetLength(1) - 1] = 'G';
            maps[15, 10] = 'B';
        }
        public override void Update()
        {
            var pos= PlayerManager.Instance.move.position;
            var  Oldpos= PlayerManager.Instance.move.Old_pos;
            if(pos.x<0 || pos.y<0 || pos.x>=20 || pos.y>=20)
            {
                Position oldpos = PlayerManager.Instance.move.Old_pos;
                PlayerManager.Instance.move.m_PlayerTransform.SetTransform(oldpos.x, oldpos.y);
                return;
            }
            maps[Oldpos.y, Oldpos.x] = ' ';
            maps[maps.GetLength(0) - 1, maps.GetLength(1) - 1] = 'G';
           
                
            maps[pos.y, pos.x] = 'P';

           
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
                    Console.Write(maps[i, j] );
                }
                Console.WriteLine();
            }
        }
    }
}
