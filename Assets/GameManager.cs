using UnityEngine;
using TMPro;
using UnityEngine.InputSystem; 


public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }


    public GameObject startText; 
    public GameObject pauseText; 
    
    private bool isGameStarted = false; 
    private bool isPaused = false;     

    void Start()
    {
        Time.timeScale = 0f; 
    }

    void Update()
    {
        if (Keyboard.current == null) return;

        if (isGameStarted == false)
        {
            
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                StartGame();
            }
        }
        else
        {
    
            if (Keyboard.current.escapeKey.wasPressedThisFrame)
            {
                TogglePause();
            }
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
        if (isPaused)
            ResumeGame();
        else
            PauseGame();
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