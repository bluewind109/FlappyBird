using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] sprites;
    private int spriteIndex = 0;

    private Vector3 direction;
    public float gravity = -9.8f;
    public float jumpStrength = 5f;

    private const int LEFT_CLICK = 0;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    public void Reset()
    {
        direction = Vector3.zero;
        transform.position = Vector3.zero;
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    private void AnimateSprite()
    {
        spriteIndex = (spriteIndex + 1) % sprites.Length;
        spriteRenderer.sprite = sprites[spriteIndex];
    }

    void Update()
    {
        if (GameManager.Instance.IsPlayerDead) return;

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(LEFT_CLICK))
        {
            direction = Vector3.up * jumpStrength;
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                direction = Vector3.up * jumpStrength;
            }
        }

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }

    private void OnDead()
    {
        CancelInvoke(nameof(AnimateSprite));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ScoreZone"))
        {
            GameManager.Instance.IncreaseScore();
        }
        else if (collision.CompareTag("DeadZone"))
        {
            // Handle player death (e.g., restart game, show game over screen)
            Debug.Log("Player died!");
            OnDead();
            GameManager.Instance.GameOver();
        }
    }
}
