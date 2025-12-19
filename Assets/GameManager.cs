using UnityEngine;
using TMPro; // 必须引用 UI
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(gameObject);
        else Instance = this;
    }

    public GameObject startText;
    public GameObject pauseText;
    
    // --- 新增：分数系统 ---
    public TextMeshProUGUI scoreText; // 拖入刚才做的 ScoreText
    public int score = 0; // 当前分数

    public void AddScore()
    {
        score++; // 分数加 1
        // 更新 UI 显示
        scoreText.text = "Score: " + score + "/10";
    }
    // --------------------

    private bool isGameStarted = false;
    private bool isPaused = false;

    void Start()
    {
        Time.timeScale = 0f; 
        // 初始化分数显示
        if(scoreText != null) scoreText.text = "Score: 0/10";
    }

    void Update()
    {
        if (Keyboard.current == null) return;

        if (!isGameStarted)
        {
            if (Keyboard.current.spaceKey.wasPressedThisFrame) StartGame();
        }
        else
        {
            if (Keyboard.current.escapeKey.wasPressedThisFrame) TogglePause();
        }
    }

    void StartGame()
    {
        isGameStarted = true;
        if(startText != null) startText.SetActive(false);
        Time.timeScale = 1f;
    }

    void TogglePause()
    {
        if (isPaused) ResumeGame();
        else PauseGame();
    }

    void PauseGame()
    {
        isPaused = true;
        if(pauseText != null) pauseText.SetActive(true);
        Time.timeScale = 0f;
    }

    void ResumeGame()
    {
        isPaused = false;
        if(pauseText != null) pauseText.SetActive(false);
        Time.timeScale = 1f;
    }
}