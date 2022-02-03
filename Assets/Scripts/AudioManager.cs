using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] playlist;
    public AudioSource audioSource;
    public AudioMixerGroup soundEffectMixer;

    private int musicIndex = 0;

    public static AudioManager instance;

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



    public void ChangeMusic(AudioClip sound)
    {
        //StartCoroutine(Fade(audioSource, 0.5f));
        //StopCoroutine(Fade(audioSource, 0.5f));
        audioSource.Stop();
        audioSource.clip = sound;
        audioSource.Play();
    }

    IEnumerator Fondu(AudioClip audioClip)
    {
        yield return new WaitForSeconds(1f);
    }

    // Start is called before the first frame update
    void Start()
    {

        audioSource.volume = PlayerPrefs.GetFloat("SliderVolumeLevel", audioSource.volume);
        audioSource.clip = playlist[0];
        audioSource.Play();

    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            
                if (CurrentSceneManager.instance.isUndertale && DialogueManager.instance.leverDown == true && DialogueManager.instance.leverFinished == false)
                {
                    print("Non");
                }

                else if (CurrentSceneManager.instance.isEnd)
            {
                print("Non");
            }

                else
                {
                    PlayNextSong();
                }
        }
            
    }

    IEnumerator Fade(AudioSource audioS, float FadeTime)
    {

        float startvolume = audioS.volume;
        while (audioS.volume >0)
        {
            audioS.volume -= startvolume * Time.deltaTime / FadeTime;
            yield return null;
        }
        audioS.Stop();
        audioS.volume = startvolume;

    }

    void PlayNextSong()
    {
        musicIndex = (musicIndex + 1) % playlist.Length;
        audioSource.clip = playlist[musicIndex];
        audioSource.Play();

    }

    public AudioSource PlayClipAt(AudioClip clip, Vector3 pos)
    {

        GameObject tempGO = new GameObject("TempAudio");
        tempGO.transform.position = pos;
        AudioSource audioSource = tempGO.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.outputAudioMixerGroup = soundEffectMixer;
        audioSource.Play();
        Destroy(tempGO, clip.length);
        return audioSource;

    }

}
