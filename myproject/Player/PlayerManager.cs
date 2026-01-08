using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SadSmile
{
    public class PlayerManager:IComponent
    {
        public static PlayerManager Instance { get; private set; }

        public PlayerManager()
        {
            Awake();
        }

        public void Awake()
        {
            if (Instance != null && Instance != this)
            {
                return;
            }
            Instance = this;
        }

        public PlayerMove move;
        public PlayerStatus status;
        
      

        public void Update() { }
    }
}
