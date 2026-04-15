using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject pipePrefab;
    [SerializeField] private float spawnInterval = 1f;
    [SerializeField] private Vector2 heightRange = new Vector2(-1f, 1f);

	private float rightBound;

	void Start()
    {
		rightBound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x + 1f;
    }

    void OnEnable()
    {
        InvokeRepeating(nameof(SpawnPipe), spawnInterval, spawnInterval);
    }

	void OnDisable()
	{
		CancelInvoke(nameof(SpawnPipe));
	}

	private void SpawnPipe()
    {
        GameObject pipe = Instantiate(pipePrefab, transform.position, Quaternion.identity);
        pipe.transform.position = new Vector3(rightBound, pipe.transform.position.y, pipe.transform.position.z);
        pipe.transform.position += Vector3.up * Random.Range(heightRange.x, heightRange.y);
    }
}
