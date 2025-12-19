using UnityEngine;

public class Kunai : MonoBehaviour
{
    public float speed = 20f; 
    public float lifeTime = 2f; 

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // --- 新增：杀敌加分 ---
            // 调用 GameManager 的 AddScore 方法
            GameManager.Instance.AddScore();
            // -------------------

            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if (!other.CompareTag("Player") && !other.CompareTag("Finish")) 
        {
             Destroy(gameObject);
        }
    }
}