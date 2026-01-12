using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SadSmile
{
    public class FirstGameScene:Scene
    {
        char[,] maps ;
        baseMap map;
        GameObject Goal = new GameObject();
        GameObject Box1=new GameObject();
        public override void Enter()
        {
            PlayerManager.Instance.move.m_PlayerTransform.SetPosition(1, 1);

            map = new firstMap();
            maps = map.GenerateMap();
            Goal.Transform.SetPosition(maps.GetLength(0) - 2, maps.GetLength(1) - 2);
            Box1.Transform.SetPosition(6, 5);
            draw();
        }

        public void draw()
        {
            var pos = PlayerManager.Instance.move.position;
            maps[pos.y, pos.x] = 'P';
            maps[Goal.Transform.position.x, Goal.Transform.position.y] = 'G';
            maps[Box1.Transform.position.y, Box1.Transform.position.x] = 'B';
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

                bool iswall = maps[Box1.Transform.position.y + dir.y, Box1.Transform.position.x + dir.x] == '#';
                bool isGoal = maps[Box1.Transform.position.y + dir.y, Box1.Transform.position.x + dir.x] == 'G';
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
                Box1.Transform.SetPosition( Box1.Transform.position.x + dir.x, Box1.Transform.position.y + dir.y);
                maps[Box1.Transform.position.y, Box1.Transform.position.x] = 'B';

            }
            maps[pos.y, pos.x] = 'P';

           
        }//update

        public override void Exit()
        {
             
        }

        public override void Render()
        {
           Console.WriteLine("입력 방향키 : →←↑↓");
           MapRender.Render(maps);
        }
    }
}
