using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private float speed;
    public float min_speed;
    public float max_speed;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        speed = Random.Range(min_speed, max_speed);
    }

    void Update()
    {
        if (player == null) return;

        Vector2 direction = (player.position - transform.position).normalized;
        transform.position += (Vector3)direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.SetActive(false);
            Debug.Log("GAME OVER - touché par ennemi");
        }
    }
}
