using UnityEngine;

public class MusicSFX_Singleton : MonoBehaviour
{
    public static MusicSFX_Singleton Instance;

    public AudioSource sourceSFX;
    public AudioSource sourceMusic;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        sourceMusic.Play();
    }

    public void StartMusic()
    {
        sourceMusic.Play();
    }

    public void SFX(AudioClip _clip)
    {
        sourceSFX.clip = _clip;
        sourceSFX.PlayOneShot(_clip);
    }
}
