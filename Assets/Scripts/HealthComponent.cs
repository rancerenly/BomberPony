using System;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField]
    protected uint health;

    public uint Health
    {
        get => health;
        protected set
        {
            health = value;
            HealthChanged?.Invoke(health);

            if (health == 0)
            {
                Death?.Invoke();
            }
        }
    }

    public event Action<uint> HealthChanged;
    public event Action Death;

    protected void Awake()
    {
        Health = health;
    }

    public virtual void Damage()
    {
        --Health;
    }
}
