using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Enemies/Enemy Data")]
public class EnemyData : ScriptableObject
{
    [Tooltip("Cantidad de daño que este enemigo inflige al jugador")]
    public int damage;

    public EnemyData Clone()
    {
        return Instantiate(this);
    }
}
