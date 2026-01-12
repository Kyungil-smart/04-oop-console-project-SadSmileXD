using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SadSmile
{
    public class TitleScene:Scene
    {
        int selectinx = 0;
        string[] name = { "게임시작", "종료" };
        public override void Enter()
        {
             
        }

        public override void Render()
        {
            if(InputManager.GetKey(ConsoleKey.DownArrow))
            {
                int idx = selectinx+1;
                selectinx = idx.Clamp(0, 1);
            }
            else if(InputManager.GetKey(ConsoleKey.UpArrow))
            {
                int idx = selectinx - 1;
                selectinx = idx.Clamp(0, 1);
            }


            Console.WriteLine("==========");
            for(int i=0; i<2; i++)
            {
                if(selectinx ==i)
                {
                    Console.WriteLine(">>"+ name[i]);
                }
                else
                {
                    Console.WriteLine("  "+name[i]);
                }
                   
            }
            Console.WriteLine("==========");
        }
        public override void Update()
        {
            if (InputManager.GetKey(ConsoleKey.Enter))
            {
                if(selectinx ==0)
                {
                    SceneManager.Change("test");
                }
                else
                {
                    Environment.Exit(0);
                }
            }
        }
        public override void Exit()
        {
             
        }
    }
}
