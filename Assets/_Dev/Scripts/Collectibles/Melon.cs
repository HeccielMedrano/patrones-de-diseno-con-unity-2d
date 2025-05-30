using System;
using UnityEngine;

public class ScoreCollectible : MonoBehaviour, ICollectibleBehavior
{
    public static event Action OnCollected;

    public void OnCollect()
    {
        Debug.Log("MELON");
        OnCollected?.Invoke();
    }
}
