using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SadSmile
{


    public class Transform : IComponent
    {
        private Position m_Position;
        //readOnly
        public  Position position => m_Position;  
      
        public Transform()
        {
            m_Position = new Position();
            m_Position.x = 0;
            m_Position.y = 0;   
        }
        
        public void SetPosition(int x, int y)
        {
            this.m_Position.x = x;
            this.m_Position.y = y;
        }

        public void MoveTransform(int x,int y)
        {
            this.m_Position.x += x;
            this.m_Position.y += y;
        }



        public void Update() { }
        
    }
}
