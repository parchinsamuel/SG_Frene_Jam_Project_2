using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float gameTime = 0f;  // timer global
    private bool gameOver = false;

    [SerializeField] private Rigidbody2D player;

    void Awake()
    {
        // Singleton pour garder le GameManager entre les scènes
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        // Timer si le jeu n'est pas terminé
        if (!gameOver)
        {
            gameTime += Time.deltaTime;
        }

        // Détection du Game Over (Player désactivé)
        if (!gameOver && player != null && !player.gameObject.activeInHierarchy)
        {
            TriggerGameOver();
        }
    }

    public void TriggerGameOver()
    {
        gameOver = true;

        // Sauvegarder le temps total pour la scène GameOver
        PlayerPrefs.SetFloat("LastGameTime", gameTime);

        // Charger la scène GameOver
        SceneManager.LoadScene("GameOver");
    }
}
