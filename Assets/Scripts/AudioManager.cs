using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource alienMusic;
    void Start()
    {
        alienMusic.Play();
    }

}
