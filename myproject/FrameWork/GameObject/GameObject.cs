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
        public void AddComponent<T>(T component) where T : IComponent
        {
            components.Add(component);
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
            Transform = new Transform();
            
        }
    }

}
