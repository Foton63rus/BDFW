using UnityEngine;

namespace BDFW
{
    internal class Game
    {
        public static GameEvent Event;
        internal Session Session;
        internal void Start()
        {
            Event = new GameEvent();
            CreateSession();
            Session.Start();
        }

        internal void FixedUpdate()
        {
            Session?.FixedUpdate();
        }

        internal void Update()
        {
            Session?.Update();
        }

        internal void LateUpdate()
        {
            Session?.LateUpdate();
        }

        internal void CreateSession()
        {
            if (Session != null) Session.Dispose();
            Session = new Session();
            Session.behaviourSystem = new BehaviourSystem();
            Session.behaviourSystem.Add(new TestBehaviour());
        }
    }
}
