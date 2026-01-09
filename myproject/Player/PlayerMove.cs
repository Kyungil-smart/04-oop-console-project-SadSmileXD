using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SadSmile
{
    public class PlayerMove : IComponent
    {
        public Transform m_PlayerTransform;

        public PlayerMove(Transform tr)
        {
            m_PlayerTransform = tr;
        }

        public PlayerMove()
        {

        }
        public Position Old_pos=new Position();
        public Position position => m_PlayerTransform.position;

        public void Update()
        {
            if (InputManager.GetKey(ConsoleKey.UpArrow))
            {
                Old_pos.x= position.x;
                Old_pos.y = position.y;
                m_PlayerTransform.MoveTransform(0, -1);
            }
            else if (InputManager.GetKey(ConsoleKey.LeftArrow))
            {
                Old_pos.x = position.x;
                Old_pos.y = position.y;
                m_PlayerTransform.MoveTransform(-1, 0);
            }
            else if (InputManager.GetKey(ConsoleKey.RightArrow))
            {
                Old_pos.x = position.x;
                Old_pos.y = position.y;
                m_PlayerTransform.MoveTransform(1, 0);
            }
            else if (InputManager.GetKey(ConsoleKey.DownArrow))
            {
                Old_pos.x = position.x;
                Old_pos.y = position.y;
                m_PlayerTransform.MoveTransform(0, 1);
            }
        }
    }
}
