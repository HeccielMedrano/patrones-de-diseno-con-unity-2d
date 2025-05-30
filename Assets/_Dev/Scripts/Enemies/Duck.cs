using UnityEngine;

public class Duck : Enemy
{
    [SerializeField] private EnemyData data;
    
    public override void Initialize()
    { }

    public override int GetDamage()
    {
        return data != null ? data.damage : 0;
    }
}
