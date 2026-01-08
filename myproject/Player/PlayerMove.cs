using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SadSmile
{
    public class PlayerMove : IComponent
    {
        private Transform m_PlayerTransform;
        public PlayerMove(Transform tr)
        {
            m_PlayerTransform = tr;
        }

        public void Update()
        {
            if (InputManager.GetKey(ConsoleKey.UpArrow))
            {
                Console.WriteLine("위");
            }
            else if (InputManager.GetKey(ConsoleKey.LeftArrow))
            {
                Console.WriteLine("왼쪽");
            }
        }
    }
}
