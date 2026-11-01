using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Handles scoring, game states (Running/Pause/Game Over), combo system, and lives.
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int Score { get; private set; }
    public int Lives { get; private set; } = 3;
    public bool IsGameOver { get; private set; }
    public int ComboCount { get; private set; }

    [SerializeField] private int startingLives = 3;

    public UnityEvent OnScoreUpdated;
    public UnityEvent OnLivesUpdated;
    public UnityEvent OnGameOver;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        Lives = startingLives;
    }

    public void AddScore(int amount)
    {
        if (IsGameOver) return;

        ComboCount++;
        int multiplier = Mathf.Clamp(ComboCount / 5, 1, 5);
        Score += (amount * multiplier);

        OnScoreUpdated?.Invoke();
    }

    public void HitBomb(int penalty)
    {
        ComboCount = 0;
        Lives--;
        OnLivesUpdated?.Invoke();

        if (Lives <= 0) TriggerGameOver();
    }

    public void CoinMissed(CoinType type)
    {
        if (type != CoinType.Bronze) ComboCount = 0; // Only major coins matter
    }

    public void ActivateMagnet(float duration)
    {
        // Placeholder for Magnet logic
        Debug.Log("Magnet Activated!");
    }

    private void TriggerGameOver()
    {
        IsGameOver = true;
        OnGameOver?.Invoke();
    }
}
