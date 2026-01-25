using UnityEngine;
using System.Collections.Generic;

public class EnemySpawnManager : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject enemyPrefab;
    public int maxEnemies;
    public float spawnEverySeconds;

    [Header("Map Bounds")]
    public BoxCollider2D mapBounds;

    private float timer = 0f;
    private List<GameObject> enemies = new List<GameObject>();

    private void Start()
    {
        Collider2D box = GetComponent<BoxCollider2D>();
        Collider2D playerCol = GameObject.FindGameObjectWithTag("Player")
                                         ?.GetComponent<Collider2D>();

        if (box != null && playerCol != null)
            Physics2D.IgnoreCollision(box, playerCol);
    }
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnEverySeconds && enemies.Count < maxEnemies)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        Vector2 spawnPos = GetRandomPositionInBounds();
        GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        enemies.Add(enemy);
    }

    Vector2 GetRandomPositionInBounds()
    {
        Bounds b = mapBounds.bounds;

        float x = Random.Range(b.min.x, b.max.x);
        float y = Random.Range(b.min.y, b.max.y);

        return new Vector2(x, y);
    }
}