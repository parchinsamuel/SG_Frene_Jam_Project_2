using UnityEngine;
using TMPro;

public class ChronoTimer : MonoBehaviour
{
    [Header("References")]

    [SerializeField] private TMP_Text textSeconde;
    [SerializeField] private TMP_Text textMinute;
    [SerializeField] private TMP_Text textHour;

    [Header("Parameters")]

    [SerializeField] public int Seconde;
    [SerializeField] public int Minute;
    [SerializeField] public int Hour;
    [SerializeField] private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        Seconde = Mathf.FloorToInt(timer);

        AddSeconde();
        TimerToZero();
    }

    void AddSeconde()
    {
        if (timer >= 60f)
        {
            AddMinute();
        }

        textSeconde.text = Seconde.ToString("00");
    }

    void AddMinute()
    {
        Minute++;

        if (Minute == 60)
        {
            AddHour();
            Minute = 0;
        }

        textMinute.text = Minute.ToString("00");
    }

    void AddHour()
    {
        Hour++;

        textHour.text = Hour.ToString("00");
    }

    void TimerToZero()
    {
        if (timer >= 60f)
        {
            timer = 0;
        }
    }
}
