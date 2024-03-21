using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// Provides a singleton for playing sound effects and music. 
/// </summary>
public class SoundManager : MonoBehaviour // To play a sound effect, write "SoundManager.Instance.PlaySound(your audioclip here)", can be played from any object -- Ilja;"
{
    private static SoundManager instance;
    private AudioSource soundEffectSource;
    public AudioSource musicSource;

    public AudioClip GetCurrentMusicClip()
    {
        return musicSource.clip;
    }

    public static SoundManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SoundManager>();
                if (instance == null)
                {
                    GameObject singleton = new GameObject(typeof(SoundManager).Name);
                    instance = singleton.AddComponent<SoundManager>();

                    // Assigning sound effect source
                    instance.soundEffectSource = singleton.AddComponent<AudioSource>(); // Assign AudioSource component to audioSource variable

                    // Assigning music source
                    instance.musicSource = singleton.AddComponent<AudioSource>(); // Assign AudioSource component to audioSource variable
                    instance.musicSource.loop = true;
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private AudioClip previousSound; // Prevents the same sound from playing twice in a row
    private AudioClip previousSong; // If that song is already playing, don't interrupt it to play it again.

    /// <summary>
    /// Triggers the play of a random sound effect from the provided array.
    /// </summary>
    /// <param name="audioclips">Sound effect clips to play, randomly chooses one from provided array.</param>
    public void PlaySound(AudioClip[] audioclips)
    {
        if (audioclips.Length != 1)
        {
            // Prevent audioClip from repeating
            while (soundEffectSource.clip == previousSound)
            {
                soundEffectSource.clip = audioclips[Random.Range(0, audioclips.Length)];
            }
        }
        else
        {
            soundEffectSource.clip = audioclips[0];
        }

        soundEffectSource.PlayOneShot(soundEffectSource.clip);
        previousSound = soundEffectSource.clip;
    }

    /// <summary>
    /// Triggers the play of a specific sound effect.
    /// </summary>
    /// <param name="audioclip">An audioclip to play.</param>
    public void PlaySound(AudioClip audioclip)
    {
        soundEffectSource.clip = audioclip;
        soundEffectSource.PlayOneShot(soundEffectSource.clip);
        previousSound = soundEffectSource.clip;

        print("playing sound");
    }

    

    /// <summary>
    /// Triggers the play of a soundtrack.
    /// </summary>
    /// <param name="audioclip">The song to play, if the provided song is already playing, it will not interrupt it.</param>
    public void PlayMusic(AudioClip audioclip)
    {
        if (audioclip == previousSong) return;

        if (audioclip == null)
        {
            print("stop!");
            musicSource.Stop();
            return;
        }  
        musicSource.clip = audioclip;
        previousSong = audioclip;
        musicSource.Play();
    }

    /// <summary>
    /// Stop all the sounds and music that are currently playing
    /// </summary>
    public void StopAllSounds()
    {
        soundEffectSource.Stop();
        musicSource.Stop();
    }
}

