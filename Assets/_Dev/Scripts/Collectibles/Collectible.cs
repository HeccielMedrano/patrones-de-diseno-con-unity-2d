using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Collectible : MonoBehaviour
{
    private ICollectibleBehavior behavior;

    private void Awake()
    {
        behavior = GetComponent<ICollectibleBehavior>();
        if (behavior == null)
        {
            Debug.LogError("No ICollectibleBehavior attached to collectible.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            behavior?.OnCollect();
            Destroy(gameObject);
        }
    }
}
