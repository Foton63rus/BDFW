using System;

namespace BDFW
{
    internal sealed class Session : IDisposable
    {
        internal BehaviourSystem behaviourSystem;

        public Session()
        {
            behaviourSystem = new BehaviourSystem();
        }
        internal void Start()
        {
            Game.Event.Invoke(new TestEvent()
            {
                sender = this,
                text = "test",
                number = 1
            });
        }
        internal void FixedUpdate()
        {
            behaviourSystem.FixedUpdate();
        }

        internal void Update()
        {
            behaviourSystem.Update();

            Game.Event.Invoke(new TestEvent()
            {
                sender = this,
                text = "test2",
                number = 2
            });
        }


        internal void LateUpdate() 
        {
            behaviourSystem.LateUpdate();
        }

        public void Dispose()
        {
            behaviourSystem.Dispose();
        }
    }
}
