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

    [Header("Spawn Distance Around Player")]
    public float minDistanceToPlayer;
    public float maxDistanceToPlayer;

    private List<GameObject> enemies = new List<GameObject>();
    private Transform player;

    private void Start()
    {
        // Récupérer le Player
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        if (p != null) player = p.transform;

        // Ignorer la collision avec le BoxCollider de la zone si nécessaire
        Collider2D box = GetComponent<Collider2D>();
        Collider2D playerCol = player?.GetComponent<Collider2D>();
        if (box != null && playerCol != null)
            Physics2D.IgnoreCollision(box, playerCol);

        // Lancer le spawn répétitif
        InvokeRepeating(nameof(SpawnEnemyIfPossible), 0f, spawnEverySeconds);
    }

    private void SpawnEnemyIfPossible()
    {
        if (enemies.Count >= maxEnemies)
            return;

        Vector2 spawnPos = GetRandomPositionNearPlayer();
        GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        enemies.Add(enemy);
    }

    private Vector2 GetRandomPositionNearPlayer()
    {
        if (player == null || mapBounds == null)
            return Vector2.zero;

        Bounds b = mapBounds.bounds;
        Vector2 spawnPos = Vector2.zero;
        int tries = 0;

        while (tries < 20)
        {
            Vector2 direction = Random.insideUnitCircle.normalized;
            float distance = Random.Range(minDistanceToPlayer, maxDistanceToPlayer);

            spawnPos = (Vector2)player.position + direction * distance;

            // Clamp pour rester dans les bounds
            spawnPos.x = Mathf.Clamp(spawnPos.x, b.min.x, b.max.x);
            spawnPos.y = Mathf.Clamp(spawnPos.y, b.min.y, b.max.y);

            if (Vector2.Distance(spawnPos, (Vector2)player.position) >= minDistanceToPlayer)
                return spawnPos;

            tries++;
        }

        // Sécurité si pas trouvé
        return (Vector2)player.position + Vector2.up * minDistanceToPlayer;
    }
}