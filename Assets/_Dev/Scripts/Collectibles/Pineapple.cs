using System;
using UnityEngine;

public class Pineapple : MonoBehaviour, ICollectibleBehavior
{
    private ParticlePool particlePool;

    public static event Action OnCollected;

    public void Awake()
    {
        particlePool = FindFirstObjectByType<ParticlePool>();
    }

    public void OnCollect()
    {
        FindFirstObjectByType<AudioManager>().PlaySFX("SFX_Powerup");
        particlePool.SpawnParticle(transform.position);
        
        var player = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        var currentStrategy = player.GetCurrentMovementStrategy();
        var newStrategy = new SpeedBoostMovement(currentStrategy, 2f);

        player.SetMovementStrategy(newStrategy);
    }
}
