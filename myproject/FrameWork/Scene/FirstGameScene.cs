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
        //////////////////////////////////////////////
        Position CurrentPosition=new Position();
        Position OldPosition=new Position();
        Position direction=new Position();
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
            GetData();
            bool isOutOfBounds = IsBlocked(CurrentPosition);
            if (isOutOfBounds)
            {
                RevertPlayer();
                return;
            }

            ClearOldPlayer();
            DrawGoal();

            bool flowControl = TryPushBox();
            if (!flowControl)
            {
                return;
            }
            DrawPlayer( );



        }//update

        private bool TryPushBox()
        {
            if (maps[CurrentPosition.y, CurrentPosition.x] == 'B')
            {
                maps[CurrentPosition.y, CurrentPosition.x] = ' ';

                bool iswall = maps[Box1.Transform.position.y + direction.y, Box1.Transform.position.x + direction.x] == '#';
                bool isGoal = maps[Box1.Transform.position.y + direction.y, Box1.Transform.position.x + direction.x] == 'G';
                if (isGoal)
                {
                    map = new GameClear();
                    maps = map.GenerateMap();
                    TextRPG.GameClear = true;
                    return false;

                }
                else if (iswall)
                {
                    Position oldpos = PlayerManager.Instance.move.Old_pos;
                    Box1.Transform.SetPosition(CurrentPosition.x, CurrentPosition.y);
                    PlayerManager.Instance.move.m_PlayerTransform.SetPosition(OldPosition.x, OldPosition.y);


                    DrawBox();
                    DrawPlayer();
                    return false;
                }

                int PosX = Box1.Transform.position.x + direction.x;
                int PosY = Box1.Transform.position.y + direction.y;
                Box1.Transform.SetPosition(PosX, PosY);
                DrawBox();
            }

            return true;
        }

        public override void Exit()
        {
             
        }

        public override void Render()
        {
           Console.WriteLine("입력 방향키 : →←↑↓");
           MapRender.Render(maps);
        }

        bool IsBlocked(Position pos)
        {
            return pos.x < 0 || pos.y < 0 ||
                   pos.x >= 20 || pos.y >= 20 ||
                   maps[pos.y, pos.x] == '#';
        }

        void RevertPlayer()
        {
            Position old = PlayerManager.Instance.move.Old_pos;
            PlayerManager.Instance.move.m_PlayerTransform.SetPosition(old.x, old.y);
        }


        private void ClearOldPlayer() => maps[OldPosition.y, OldPosition.x] = ' ';

        private void DrawPlayer() => maps[CurrentPosition.y, CurrentPosition.x] = 'P';

        private void DrawGoal() => maps[Goal.Transform.position.x, Goal.Transform.position.y] = 'G';

        private void DrawBox() => maps[Box1.Transform.position.y, Box1.Transform.position.x] = 'B';

        private void GetData()
        {
            CurrentPosition = PlayerManager.Instance.move.position;
            OldPosition = PlayerManager.Instance.move.Old_pos;
            direction = CurrentPosition.GetDirection(OldPosition); // - Oldpos;

        }


    }
}
