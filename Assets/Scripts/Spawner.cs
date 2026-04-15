using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject pipePrefab;
    [SerializeField] private float spawnInterval = 1f;
    [SerializeField] private Vector2 heightRange = new Vector2(-1f, 1f);

    private float rightBound;

    private float timer = 0f;

    void Start()
    {
        rightBound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x + 1f;
    }

    void Update()
    {
        if (GameManager.Instance.IsPlayerDead) return;

        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnPipe();
            timer = 0f;
        }
    }

    private void SpawnPipe()
    {
        GameObject pipe = Instantiate(pipePrefab, transform.position, Quaternion.identity);
        pipe.transform.SetParent(transform);
        pipe.transform.position = new Vector3(rightBound, pipe.transform.position.y, pipe.transform.position.z);
        pipe.transform.position += Vector3.up * Random.Range(heightRange.x, heightRange.y);
    }

    public void Reset()
    {
        // Remove all existing pipes
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        timer = 0f;
    }
}
