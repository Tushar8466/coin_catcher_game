using UnityEngine;

/// <summary>
/// Controls player movement (Basket/Catcher) via Keyboard (A/D, Left/Right) or Mouse position.
/// Clamps player within the camera screen bounds.
/// </summary>
public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 15f;
    [SerializeField] private bool useMouseControl = false;

    [Header("Boundary Padding")]
    [SerializeField] private float sidePadding = 0.8f;

    private float minX;
    private float maxX;
    private Camera mainCamera;
    private Vector3 initialPosition;

    private void Start()
    {
        mainCamera = Camera.main;
        initialPosition = transform.position;
        CalculateScreenBounds();
    }

    private void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.IsGameOver)
            return;

        CalculateScreenBounds();

        if (useMouseControl)
        {
            HandleMouseInput();
        }
        else
        {
            HandleKeyboardInput();
        }
    }

    private void HandleKeyboardInput()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        Vector3 pos = transform.position;
        pos.x += inputX * moveSpeed * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, minX + sidePadding, maxX - sidePadding);
        transform.position = pos;
    }

    private void HandleMouseInput()
    {
        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(mouseWorldPos.x, minX + sidePadding, maxX - sidePadding);
        transform.position = pos;
    }

    private void CalculateScreenBounds()
    {
        if (mainCamera == null) mainCamera = Camera.main;
        if (mainCamera == null) return;

        float distance = transform.position.z - mainCamera.transform.position.z;
        minX = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, distance)).x;
        maxX = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, distance)).x;
    }

    public void ResetPosition()
    {
        transform.position = initialPosition;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Coin coin = other.GetComponent<Coin>();
        if (coin != null)
        {
            coin.OnCaught();
        }
    }
}
