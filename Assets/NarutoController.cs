using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.InputSystem;

public class NarutoController : MonoBehaviour
{
    public float speed = 10.0f; //moving speed
    public TextMeshProUGUI uiText; 
    
    private bool isGameOver = false; //flag to check game over

    void Update()
    {
        // check null
        if (Keyboard.current == null) return;

        //move when game not over
        if (isGameOver == false)
        {
            float moveX = 0;
            float moveZ = 0;

            //input
            
            // a
            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            {
                moveX = -1;
            }
            // d
            else if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            {
                moveX = 1;
            }

            // w
            if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
            {
                moveZ = 1;
            }
            // s
            else if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
            {
                moveZ = -1;
            }

            //direction vector
            Vector3 move = new Vector3(moveX, 0, moveZ) * speed * Time.deltaTime;
            
            //body move
            transform.Translate(move);
        }

        // restart using R
        if (isGameOver == true && Keyboard.current.rKey.wasPressedThisFrame)
        {
            // 重新加载当前场景
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        //if hit scroll
        if (collision.gameObject.CompareTag("Finish"))
        {
            uiText.text = "You Win! Press R"; 
            uiText.color = Color.green;      
            isGameOver = true;               
        }
        
        // if hit enemy
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            uiText.text = "You Lose! Press R"; 
            uiText.color = Color.red;         
            isGameOver = true;                
        }
    }
}