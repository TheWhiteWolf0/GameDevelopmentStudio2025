using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("-------------- Audio Source --------------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("-------------- Audio Clips --------------")]
    public AudioClip backGround;
    public AudioClip walk;
    public AudioClip jump;
    public AudioClip fallDeath;
    public AudioClip sunBeam;
    public AudioClip drag;
    public AudioClip plant;
    public AudioClip unplant;

    private void Start()
    {
        musicSource.clip = backGround;
        musicSource.Play();
    }

    public void PlayerSFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
