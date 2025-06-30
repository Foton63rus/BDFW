using System.Collections.Generic;
using UnityEngine;

namespace BDFW
{
    public class MonoEntity : MonoBehaviour
    {
        public Entity Entity;

        private void Awake()
        {
            Entity = new Entity(transform);
        }
    }
}
