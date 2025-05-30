using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private TMP_Text hudText;

    private int collectiblesCount = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        Melon.OnCollected += IncreaseCollectibleCount;
    }

    public void IncreaseCollectibleCount()
    {
        collectiblesCount++;
        hudText.text = "x " + collectiblesCount;
    }
}
