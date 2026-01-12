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
        public static bool GameClear=false;
        public override void Run()
        {
            base.Run();
        }

        public override void Awake()
        {
           //게임오브젝트 생성
            Player = new GameObject();
            Player.Transform.SetPosition(1, 1);
            //컴포넌트 생성하고 데이터 입력
            Player.AddComponent<PlayerStatus>();
            var status = Player.GetComponent<PlayerStatus>();
            status.SetStatus(500, 500, "이인");
            //
            var TransformData = Player.Transform;
            //이동 처리 로직
            Player.AddComponent<PlayerMove>();
            var movedata=Player.GetComponent<PlayerMove>();

            movedata.m_PlayerTransform = Player.GetComponent<Transform>();
            //
            Player.AddComponent<PlayerManager>();
            //연결
            PlayerManager.Instance.status = status;
            PlayerManager.Instance.move = movedata;

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
