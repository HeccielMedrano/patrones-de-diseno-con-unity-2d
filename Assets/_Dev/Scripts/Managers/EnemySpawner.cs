using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyFactory factory;
    [SerializeField] private EnemyType enemyType;

    private void Start()
    {
        factory.CreateEnemy(enemyType, transform.position);
    }
}
