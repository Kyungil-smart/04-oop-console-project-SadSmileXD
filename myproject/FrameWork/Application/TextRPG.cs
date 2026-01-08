using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace SadSmile
{
    public class TextRPG : App
    {
        GameObject Player; 
        
        public override void Run()
        {
            base.Run();
        }

        public override void Awake()
        {
            Player = new GameObject();
            Player.AddComponent(new PlayerStatus("김재성"));
         
           var Data=Player.GetComponent<PlayerStatus>();
            Data.StatusPrintf();


        }

        public override void OnEnable()
        {
             
        }

        public override void Start()
        {
             
        }

        public override void Update()
        {

            if (InputManager.GetKey(ConsoleKey.UpArrow))
             {
                Console.WriteLine("I누름");
             }
        }
    }
}
