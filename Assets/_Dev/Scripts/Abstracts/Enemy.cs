using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public abstract void Initialize();

    public virtual int GetDamage()
    {
        return 1;
    }
}
