using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private Player player;
    [SerializeField] private Spawner spawner;
    [SerializeField] private TextMeshProUGUI scoreText;
    
    private const int LEFT_CLICK = 0;

    private int score = 0;

    public bool IsPlayerDead { get; private set; } = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        Instance = null;
    }

    void Start()
    {
        UpdateScoreText();
    }

    private void Reset()
    {
        player.Reset();
        spawner.Reset();
        score = 0;
        UpdateScoreText();
        IsPlayerDead = false;
    }

	public void GameOver()
	{
		IsPlayerDead = true;
	}

	public void IncreaseScore()
    {
        score++;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }

    void Update()
    {
        if (IsPlayerDead)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(LEFT_CLICK))
            {
                Reset();
            }
            return;
        }
    }
}
