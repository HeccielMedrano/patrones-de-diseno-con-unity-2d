using UnityEngine;

public enum EnemyType
{
    Duck,
    Chicken
}

[CreateAssetMenu(menuName = "Factory/EnemyFactory")]
public class EnemyFactory : ScriptableObject
{
    [SerializeField] private GameObject duckPrefab;
    [SerializeField] private GameObject chickenPrefab;

    public Enemy CreateEnemy(EnemyType type, Vector3 spawnPosition)
    {
        GameObject enemyGO = null;

        switch (type)
        {
            case EnemyType.Duck:
                enemyGO = Instantiate(duckPrefab, spawnPosition, Quaternion.identity);
                break;
            case EnemyType.Chicken:
                enemyGO = Instantiate(chickenPrefab, spawnPosition, Quaternion.identity);
                break;
            default:
                Debug.LogError("Unknown enemy type");
                return null;
        }

        Enemy enemy = enemyGO.GetComponent<Enemy>();
        enemy.Initialize();
        return enemy;
    }
}
