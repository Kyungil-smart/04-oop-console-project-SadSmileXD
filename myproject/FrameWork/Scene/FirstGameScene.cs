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
        bool isOutOfBounds = false;
        //////////////////////////////////////////////
        baseMap map = new firstMap();
        GameObject Goal = new GameObject();
        GameObject Box1=new GameObject();

        Position CurrentPosition=new Position();
        Position OldPosition=new Position();
        Position direction=new Position();
        //////////////////////////////////////////////

        //////////////////////////////////////////////
        public override void Exit()
        {

        }

        public override void Enter()
        {
            Init();
            draw();
        }
        public override void Render()
        {
            Console.WriteLine("입력 방향키 : →←↑↓");
            MapRender.Render(maps);
        }
        public override void Update()
        {
            GetData();
            IsBlocked();
            RevertPlayer();
            TryPushBox();
            ClearOldPlayer();
            DrawBox();
            DrawPlayer();
        }
     

      

////////////////////////////////////////////////////////////

        private void Init()
        {
            PlayerManager.Instance.move.m_PlayerTransform.SetPosition(1, 1);

 
            maps = map.GenerateMap();
            Goal.Transform.SetPosition(maps.GetLength(0) - 2, maps.GetLength(1) - 2);
            Box1.Transform.SetPosition(6, 5);
        }

        public void draw()
        {
            CurrentPosition = PlayerManager.Instance.move.position;
            DrawPlayer();
            DrawGoal();
            DrawBox();
        }

        void IsBlocked()
        {
            isOutOfBounds= CurrentPosition.x < 0 || CurrentPosition.y < 0 ||
                   CurrentPosition.x >= 20 || CurrentPosition.y >= 20 ||
                   maps[CurrentPosition.y, CurrentPosition.x] == '#';
        }

        void RevertPlayer()
        {
            if(isOutOfBounds)
            {
                Position old = PlayerManager.Instance.move.Old_pos;
                PlayerManager.Instance.move.m_PlayerTransform.SetPosition(old.x, old.y);
                GetData();
            }
          
        }

        private void TryPushBox()
        {
            if (isOutOfBounds) return;

            if (maps[CurrentPosition.y, CurrentPosition.x] == 'B')
            {
                maps[CurrentPosition.y, CurrentPosition.x] = ' ';

                bool iswall = maps[Box1.Transform.position.y + direction.y, Box1.Transform.position.x + direction.x] == '#';
                bool isGoal = maps[Box1.Transform.position.y + direction.y, Box1.Transform.position.x + direction.x] == 'G';
                if (isGoal)
                {
                    map = new GameClear();
                    maps = map.GenerateMap();
                    Console.Clear();
                    MapRender.Render(maps);
                    Environment.Exit(0);
                    return;

                }
                else if (iswall)
                {
                    PlayerManager.Instance.move.m_PlayerTransform.SetPosition(OldPosition.x, OldPosition.y);
                    CurrentPosition = OldPosition;
                    return;
                }

                int PosX = Box1.Transform.position.x + direction.x;
                int PosY = Box1.Transform.position.y + direction.y;
                Box1.Transform.SetPosition(PosX, PosY);
                DrawBox();
            }


        }
        private void ClearOldPlayer()
        {
            if (isOutOfBounds) return;
            maps[OldPosition.y, OldPosition.x] = ' ';
        }
        private void DrawPlayer()
        {
            if (isOutOfBounds) return;
            maps[CurrentPosition.y, CurrentPosition.x] = 'P';
        }
        private void DrawGoal()
        {
            if (isOutOfBounds) return;
            maps[Goal.Transform.position.x, Goal.Transform.position.y] = 'G';
        }
        private void DrawBox()
        {
            if (isOutOfBounds) return;
            maps[Box1.Transform.position.y, Box1.Transform.position.x] = 'B';
        }
        private void GetData()
        {
            CurrentPosition = PlayerManager.Instance.move.position;
            OldPosition = PlayerManager.Instance.move.Old_pos;
            direction = CurrentPosition.GetDirection(OldPosition); // - Oldpos;

        }


    }
}
