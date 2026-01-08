using System;
namespace SadSmile
{
 
   public struct Tile
   {
        // 타일 위에 뭐가 올라와있는지?
        public GameObject OnTileObject;
       // 타일 위에 올라서면 발생해야 하는 이벤트
        public event Action OnStepPlayer;
        // 자신의 좌표
        public Vector m_Position;
       
       public bool HasGameObject => OnTileObject != null;

        public Tile(Vector position)
        {
            m_Position = position;
            OnTileObject = null;
            OnStepPlayer = null;
        }

        public void Print()
       {
           if(HasGameObject)
           {
               OnTileObject.Symbol.Print();
           }
           else
           {
               ' '.Print();
           }
       }
   }
}