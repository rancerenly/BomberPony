using Game;
using UnityEngine;

namespace Creators
{
    /// <summary>
    /// Class that creates object on timer elapsed.
    /// </summary>
    [RequireComponent(typeof(Timer))]
    public class TimerCreator : ObjectCreator<GameObject>
    {
        private Timer timer;

        private void Awake()
        {
            timer = GetComponent<Timer>();
        }

        private void OnEnable()
        {
            timer.TimeElapsed += OnTimeElapsed;
        }

        private void OnDisable()
        {
            timer.TimeElapsed -= OnTimeElapsed;
        }

        public override GameObject Create()
        {
            Position = transform.position;
            Rotation = Quaternion.identity;
            
            return base.Create();
        }

        private void OnTimeElapsed()
        {
            Create();
        }
    }
}