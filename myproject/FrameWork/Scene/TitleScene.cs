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
        baseMap map;
        GameObject Goal = new GameObject();

        public override void Enter()
        {
            map = new firstMap();
            maps = map.GenerateMap();
            Goal.Transform.SetPosition(maps.GetLength(0) - 2, maps.GetLength(1) - 2);
            draw();
        }

        public void draw()
        {
            var pos = PlayerManager.Instance.move.position;
            maps[pos.y, pos.x] = 'P';
            maps[Goal.Transform.position.x, Goal.Transform.position.y] = 'G';
            maps[15, 6] = 'B';
        }

        public override void Update()
        {
            var pos= PlayerManager.Instance.move.position;
            var Oldpos= PlayerManager.Instance.move.Old_pos;
            var dir = pos - Oldpos;
         
            bool isOutOfBounds =pos.x < 0 || pos.y < 0 || pos.x >= 20 || pos.y >= 20|| maps[pos.y, pos.x]=='#';
            if (isOutOfBounds)
            {
                Position oldpos = PlayerManager.Instance.move.Old_pos;
                PlayerManager.Instance.move.m_PlayerTransform.SetPosition(oldpos.x, oldpos.y);
                return;
            }

            maps[Oldpos.y, Oldpos.x] = ' ';
            maps[Goal.Transform.position.x, Goal.Transform.position.y] = 'G';
         
            if (maps[pos.y, pos.x] == 'B')
            {
                maps[pos.y, pos.x] = ' ';

                bool iswall = maps[pos.y + dir.y, pos.x + dir.x] == '#';
                bool isGoal = maps[pos.y + dir.y, pos.x + dir.x] == 'G';
                if (isGoal)
                {
                    map=new GameClear();
                    maps = map.GenerateMap();
                   
                    TextRPG.GameClear = true;
                    return;

                }
                else if (iswall)
                {
                    Position oldpos = PlayerManager.Instance.move.Old_pos;
                    PlayerManager.Instance.move.m_PlayerTransform.SetPosition(oldpos.x, oldpos.y);
                    maps[pos.y , pos.x ] = 'B';
                    maps[Oldpos.y, Oldpos.x] = 'P';
                    return;
                }
                maps[pos.y + dir.y, pos.x + dir.x] = 'B';

            }
            maps[pos.y, pos.x] = 'P';

           
        }//update

        public override void Exit()
        {
             
        }

        public override void Render()
        {
           Console.WriteLine("입력 방향키 : →←↑↓");

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
