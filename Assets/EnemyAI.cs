using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed = 3.0f; // 敌人跑得比主角慢一点
    private Transform player;  // 记录主角的位置

    void Start()
    {
        // 游戏一开始，敌人就去全世界寻找身上贴着 "Player" 标签的人
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        
        // 如果找到了
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
    }

    void Update()
    {
        // 如果主角还活着(没被删掉)
        if (player != null)
        {
            // 1. 盯着主角看 (面向主角)
            transform.LookAt(player);
            
            // 2. 向前跑 (因为已经盯着主角了，向前就是向着主角跑)
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}