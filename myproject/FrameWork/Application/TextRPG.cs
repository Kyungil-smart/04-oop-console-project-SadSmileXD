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
            var Data=Player.GetComponent<Transform>();
            Player.AddComponent(new PlayerMove(Data));
            ///
            SceneManager.OnChangeScene += InputManager.ResetKey;
            SceneManager.AddScene("test", new TitleScene());
            SceneManager.Change("test");
        }

        public override void OnEnable()
        {
             
        }

        public override void Start()
        {
             
        }

        public override void Update()
        {
           Console.Clear();
            SceneManager.Render();
            InputManager.GetUserInput();
            Player?.Update();
            SceneManager.Update();
        }
    }
}
