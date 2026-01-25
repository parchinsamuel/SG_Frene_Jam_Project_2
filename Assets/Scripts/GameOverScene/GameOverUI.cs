using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TMP_Text textHour;
    [SerializeField] private TMP_Text textMinute;
    [SerializeField] private TMP_Text textSeconde;

    void Start()
    {
        // Récupère le temps de jeu sauvegardé dans PlayerPrefs
        float totalTime = PlayerPrefs.GetFloat("LastGameTime", 0f);

        // Conversion en heures / minutes / secondes
        int hour = Mathf.FloorToInt(totalTime / 3600f);
        int minute = Mathf.FloorToInt((totalTime % 3600f) / 60f);
        int seconde = Mathf.FloorToInt(totalTime % 60f);

        // Affichage
        if (textHour != null) textHour.text = hour.ToString("00");
        if (textMinute != null) textMinute.text = minute.ToString("00");
        if (textSeconde != null) textSeconde.text = seconde.ToString("00");
    }
}
