using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SadSmile
{
    public class GameObject
    {
        private List<IComponent> components = new List<IComponent>();
        public Transform Transform;
        public void AddComponent<T>() where T : IComponent,new()
        {
            T Data=new T();
            components.Add(Data);
        }

        public T GetComponent<T>() where T : IComponent
        {
            return components.OfType<T>().FirstOrDefault();
        }

        public void Update()
        {
            foreach (var c in components)
                c.Update();
        }

        public GameObject()
        {
            AddComponent<Transform>();
            Transform = GetComponent<Transform>();
        }
    }

}
