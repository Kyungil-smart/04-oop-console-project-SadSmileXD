using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
namespace SadSmile
{
    
 
    public  class App
    {
        public virtual void Awake()
        { 

        }
        public virtual void Start()
        {

        }
        public virtual void OnEnable() 
        { 

        }
        public virtual void Update() 
        {

        }
    
        public virtual void Run()
        {
         
            Awake();
            OnEnable();
            Start();
            while (true)
            {
               
                Update();
            }
        }

    }
}
