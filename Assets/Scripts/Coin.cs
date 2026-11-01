using UnityEngine;

public enum CoinType
{
    Bronze,
    Silver,
    Gold,
    Diamond,
    Bomb,
    Magnet
}

/// <summary>
/// Handles individual falling coin / bomb logic, movement speed, score value, and collision events.
/// </summary>
public class Coin : MonoBehaviour
{
    [Header("Item Properties")]
    public CoinType type = CoinType.Gold;
    public int pointValue = 10;
    public float fallSpeed = 5f;
    public float rotationSpeed = 90f;

    [Header("Visual Effects")]
    [SerializeField] private GameObject catchParticlePrefab;
    [SerializeField] private AudioClip catchSound;

    private bool isCaught = false;

    private void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.IsGameOver)
            return;

        // Fall downward
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);

        // Spin effect for coins
        if (type != CoinType.Bomb)
        {
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }
    }

    /// <summary>
    /// Called when player catches this item.
    /// </summary>
    public void OnCaught()
    {
        if (isCaught) return;
        isCaught = true;

        if (GameManager.Instance != null)
        {
            if (type == CoinType.Bomb)
            {
                GameManager.Instance.HitBomb(pointValue);
            }
            else if (type == CoinType.Magnet)
            {
                GameManager.Instance.ActivateMagnet(5f);
                GameManager.Instance.AddScore(pointValue);
            }
            else
            {
                GameManager.Instance.AddScore(pointValue);
            }
        }

        // Spawn particle FX
        if (catchParticlePrefab != null)
        {
            Instantiate(catchParticlePrefab, transform.position, Quaternion.identity);
        }

        // Play SFX
        if (catchSound != null && AudioManager.Instance != null)
        {
            AudioManager.Instance.PlaySFX(catchSound);
        }

        Destroy(gameObject);
    }

    /// <summary>
    /// Called when item falls below the bottom boundary.
    /// </summary>
    public void OnMissed()
    {
        if (isCaught) return;

        // Missing a regular coin breaks combo or deducts life if configured
        if (type != CoinType.Bomb && GameManager.Instance != null)
        {
            GameManager.Instance.CoinMissed(type);
        }

        Destroy(gameObject);
    }
}
