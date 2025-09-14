using UnityEngine;

public class GameProgress : MonoBehaviour
{
    public static GameProgress Instance { get; private set; }

    // 0: Hub başlangıç, 1: Baba Odası bitti, 2: Anne bitti, 3: Çocuk bitti
    public int StageIndex { get; private set; } = 0;

    void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
        // İstersen sahneler arasında kalsın:
        // DontDestroyOnLoad(gameObject);
    }

    public void Advance()
    {
        StageIndex = Mathf.Clamp(StageIndex + 1, 0, 3);
        Debug.Log($"[Progress] StageIndex = {StageIndex}");
    }
}
