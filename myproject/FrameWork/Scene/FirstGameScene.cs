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
        char[,] map ;
        bool isOutOfBounds = false;
//////////////////////////////////////////////
        baseMap mapData = new firstMap();
        GameObject Goal = new GameObject();
        GameObject Box1=new GameObject();

        Position CurrentPosition=new Position();
        Position OldPosition=new Position();
        Position direction=new Position();
//////////////////////////////////////////////

        public override void Exit()
        {

        }

        public override void Enter()
        {
            CurrentPosition = PlayerManager.Instance.move.position;
            Init();
            draw();
        }
        public override void Render()
        {
            Console.WriteLine("입력 방향키 : →←↑↓");
            MapRenderUtil.Render(map);
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

            map = mapData.GenerateMap();
            Goal.Transform.SetPosition(map.GetLength(0) - 2, map.GetLength(1) - 2);
            Box1.Transform.SetPosition(6, 5);
        }

        public void draw()
        {
           
            DrawPlayer();
            DrawGoal();
            DrawBox();
        }

        void IsBlocked()
        {
            isOutOfBounds= CurrentPosition.x < 0 || CurrentPosition.y < 0 ||
                   CurrentPosition.x >= 20 || CurrentPosition.y >= 20 ||
                   map[CurrentPosition.y, CurrentPosition.x] == '#';
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

            if (map[CurrentPosition.y, CurrentPosition.x] == 'B')
            {
                map[CurrentPosition.y, CurrentPosition.x] = ' ';

                bool iswall = map[Box1.Transform.position.y + direction.y, Box1.Transform.position.x + direction.x] == '#';
                bool isGoal = map[Box1.Transform.position.y + direction.y, Box1.Transform.position.x + direction.x] == 'G';
                if (isGoal)
                {
                    mapData = new GameClear();
                    map = mapData.GenerateMap();
                    Console.Clear();
                    MapRenderUtil.Render(map);
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
            map[OldPosition.y, OldPosition.x] = ' ';
        }
        private void DrawPlayer()
        {
            if (isOutOfBounds) return;
            MapRenderUtil.PlayerRender(map, CurrentPosition);
        }
        private void DrawGoal()
        {
            if (isOutOfBounds) return;
            MapRenderUtil.GoalRender(map,Goal.Transform.position);
        }
        private void DrawBox()
        {
            if (isOutOfBounds) return;
            MapRenderUtil.BoxRender(map, Box1.Transform.position);
        }
        private void GetData()
        {
            CurrentPosition = PlayerManager.Instance.move.position;
            OldPosition = PlayerManager.Instance.move.Old_pos;
            direction = CurrentPosition.GetDirection(OldPosition); // - Oldpos;

        }


    }
}
