using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePool : MonoBehaviour
{
    [SerializeField] private GameObject particlePrefab;
    [SerializeField] private int poolSize = 5;

    private Queue<GameObject> pool = new Queue<GameObject>();
    private HashSet<GameObject> activeParticles = new HashSet<GameObject>();

    private void Awake()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(particlePrefab, transform);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
    }

    public void SpawnParticle(Vector3 position)
    {
        GameObject particle;

        if (pool.Count > 0)
        {
            particle = pool.Dequeue();
        }
        else
        {
            Debug.LogWarning("No hay partículas disponibles en el pool. Considera aumentar el tamaño.");
            return;
        }

        activeParticles.Add(particle);
        particle.transform.position = position;
        particle.SetActive(true);

        StartCoroutine(DisableAfterDuration(particle, 0.45f));
    }

    private IEnumerator DisableAfterDuration(GameObject particle, float time)
    {
        yield return new WaitForSeconds(time);
        particle.SetActive(false);

        // Devuelve al pool
        activeParticles.Remove(particle);
        pool.Enqueue(particle);
    }
}
