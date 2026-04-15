using UnityEngine;

public class Pipes : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private float leftBound;

	void Start()
	{
		leftBound = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
	}

	void Update()
    {
        if (GameManager.Instance.IsPlayerDead) return;

        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }
    }
}
