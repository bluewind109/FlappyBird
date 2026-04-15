using UnityEngine;

public class Parallax : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    public float scrollSpeed = 1f;

	void Awake()
	{
		meshRenderer = GetComponent<MeshRenderer>();
	}

    void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(scrollSpeed, 0) * Time.deltaTime;
    }
}
