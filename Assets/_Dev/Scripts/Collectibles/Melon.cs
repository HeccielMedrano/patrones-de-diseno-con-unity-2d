using System;
using UnityEngine;

public class Melon : MonoBehaviour, ICollectibleBehavior
{
    private ParticlePool particlePool;

    public static event Action OnCollected;

    public void Awake()
    {
        particlePool = FindFirstObjectByType<ParticlePool>();
    }

    public void OnCollect()
    {
        FindFirstObjectByType<AudioManager>().PlaySFX("SFX_Collectable");
        particlePool.SpawnParticle(transform.position);
        OnCollected?.Invoke();
    }
}
