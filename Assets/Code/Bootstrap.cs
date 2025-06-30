using UnityEngine;
namespace BDFW
{
    internal sealed class Bootstrap : MonoBehaviour
    {
        private Game Game;
        private Session _session;

        private void Awake()
        {
            init();
            Game = new Game();
        }

        private void Start()
        {
            Game.Start();
        }
        
        private void FixedUpdate()
        {
            Game.FixedUpdate();
        }

        private void Update()
        {
            Game.Update();
        }

        private void LateUpdate()
        {
            Game.LateUpdate();
        }

        private void init()
        {
            Destroy(GameObject.Find("bootstrapper"));
            this.gameObject.name = "bootstrapper";
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
