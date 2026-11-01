using UnityEngine;

public class BottomBoundary : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Coin coin = other.GetComponent<Coin>();
        if (coin != null)
        {
            coin.OnMissed();
        }
        else
        {
            Destroy(other.gameObject); // Cleanup anything else
        }
    }
}
