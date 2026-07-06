using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSrc;
    private static MusicManager instance;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        SceneManager.sceneLoaded += OnSceneLoaded;
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Title_Screne")
        {
            audioSrc.Stop();
        }
        else if (scene.name == "Credits")
        {
            audioSrc.Stop();
        }
        else
        {
            if (!audioSrc.isPlaying)
                audioSrc.Play();
        }
    }
}
