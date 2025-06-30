using System;
using UnityEngine;

namespace BDFW
{
    [Serializable]
    public class Entity
    {
        public int Id;
        public Transform Transform;
        public GODataHolder Data;
        public GOBehaviourHolder Behaviour;
        public Entity(Transform transform)
        {
            Transform = transform;
            Id = Transform.GetInstanceID();
            Data = new GODataHolder(Id);
            Behaviour = new GOBehaviourHolder(Id);
        }
    }
}
