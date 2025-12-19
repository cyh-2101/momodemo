using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.InputSystem; // 必须有这行

public class NarutoController : MonoBehaviour
{
    public float speed = 10.0f;
    public TextMeshProUGUI uiText;
    
    // --- 新增变量：苦无模版 ---
    public GameObject kunaiPrefab; 
    // -------------------------

    private bool isGameOver = false;

    void Update()
    {
        if (Keyboard.current == null) return;

        if (isGameOver == false)
        {
            // 1. 移动逻辑 (保持不变)
            float moveX = 0;
            float moveZ = 0;
            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) moveX = -1;
            else if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) moveX = 1;
            
            if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed) moveZ = 1;
            else if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed) moveZ = -1;

            Vector3 move = new Vector3(moveX, 0, moveZ) * speed * Time.deltaTime;
            transform.Translate(move);

            // --- 2. 新增：发射逻辑 ---
            // 如果按下了 J 键
            if (Keyboard.current.jKey.wasPressedThisFrame)
            {
                Shoot();
            }
            // -----------------------
        }

        if (isGameOver == true && Keyboard.current.rKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    // --- 新增：发射函数 ---
    void Shoot()
    {
        // 在主角前方一点点的位置生成苦无 (防止卡在自己身体里)
        Vector3 spawnPos = transform.position + transform.forward * 1.5f;
        
        // Instantiate 意思是“生成/克隆”
        // 参数：(生成什么, 在哪生成, 旋转角度)
        Instantiate(kunaiPrefab, spawnPos, transform.rotation);
    }
    // --------------------

void OnCollisionEnter(Collision collision)
    {
        // 如果撞到了卷轴 (Finish)
        if (collision.gameObject.CompareTag("Finish"))
        {
            // --- 新增：检查分数 ---
            if (GameManager.Instance.score >= 10)
            {
                // 分数够了，赢！
                uiText.text = "You Win! Press R"; 
                uiText.color = Color.green;      
                isGameOver = true;
                Time.timeScale = 0f; // 赢了之后暂停游戏
            }
            else
            {
                // 分数不够，提示一下
                uiText.text = "Need 10 Points!";
                uiText.color = Color.yellow;
            }
            // --------------------
        }
        
        // 如果撞到了敌人 (Enemy)
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            uiText.text = "You Lose! Press R"; 
            uiText.color = Color.red;         
            isGameOver = true;     
            Time.timeScale = 0f; // 输了之后暂停游戏           
        }
    }
}