using System;
using System.Collections;
using UnityEngine;

public class Timer
{
    public event Action TimerFinished;
    public event Action<float> TimeChanged;
    
    public bool IsRunning { get; private set; }
    
    private float time;
    private readonly MonoBehaviour coroutineRunner;
    
    public Timer(MonoBehaviour coroutineRunner, float duration)
    {
        this.coroutineRunner = coroutineRunner;
        Restart(duration);
    }

    public void Restart(float duration)
    {
        time = duration;
        IsRunning = true;
        coroutineRunner.StartCoroutine(Process());
    }

    private IEnumerator Process()
    {
        while (time > 0)
        {
            time -= Time.deltaTime;
            TimeChanged?.Invoke(time);
            yield return null;
        }
        
        IsRunning = false;
        TimerFinished?.Invoke();
    }
}