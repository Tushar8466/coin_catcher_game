using UnityEngine;
using TMPro; // Assuming TextMeshPro usage

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private GameObject gameOverPanel;

    private void Start()
    {
        GameManager.Instance.OnScoreUpdated.AddListener(UpdateUI);
        GameManager.Instance.OnLivesUpdated.AddListener(UpdateUI);
        GameManager.Instance.OnGameOver.AddListener(ShowGameOver);
        UpdateUI();
    }

    private void UpdateUI()
    {
        scoreText.text = $"Score: {GameManager.Instance.Score}";
        livesText.text = $"Lives: {GameManager.Instance.Lives}";
    }

    private void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
    }
}
