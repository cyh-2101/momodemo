using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // 我们要生成的敌人模版
    public float spawnInterval = 3.0f; // 每隔几秒生一个？

    // 刷怪范围 (X 和 Z 的坐标范围)
    // 比如 xRange = 10，意思是可以在 -10 到 10 之间随机生成
    public float xRange = 10.0f; 
    public float zRange = 10.0f; 

    void Start()
    {
        // InvokeRepeating 意思就是：重复调用某个函数
        // 参数：("函数名", 第一次等待几秒, 之后每隔几秒)
        InvokeRepeating("SpawnEnemy", 1.0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        // 1. 随机计算一个位置
        // Random.Range(-10, 10) 会在这个范围内随机挑一个数
        float randomX = Random.Range(-xRange, xRange);
        float randomZ = Random.Range(-zRange, zRange);

        // 组合成一个新的位置坐标 (Y轴保持0.5，防止埋在地里)
        Vector3 spawnPos = new Vector3(randomX, 0.5f, randomZ);

        // 2. 生成敌人 (通灵之术！)
        // Instantiate(生成什么, 在哪生成, 旋转角度)
        Instantiate(enemyPrefab, spawnPos, enemyPrefab.transform.rotation);
    }
}