using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace SadSmile
{
    public class PlayerStatus: IComponent
    {
        private string m_name;
        private int m_hp;
        private int m_mp;

        ///ReadOnly
        public int Hp=>m_hp;
        public int Mp=>m_mp;    
        public string name => m_name;
        ///
        public PlayerStatus(string name)
        {
            this.m_name = name;
            m_hp = 5000;
            m_mp = 500;
        }

        public void StatusPrintf()
        {
            int width = 18;

            string nameLine = $"이름:{name}";
            string hpLine =  $"체력:{m_hp}";
            string mpLine = $"마나:{m_mp}";

            Console.WriteLine("####################");
         
            Console.WriteLine( nameLine);
            Console.WriteLine( hpLine );
            Console.WriteLine( mpLine );
            
            Console.WriteLine("####################");
        }
     
        public void Update() { }
    }
}
