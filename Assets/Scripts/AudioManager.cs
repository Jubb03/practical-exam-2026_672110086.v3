using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

namespace chadsadaporn_babpa.Exam
{
    // ???????? MainMenu ???????? (DontDestroyOnLoad)
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance;

        [SerializeField] AudioMixer mixer;
        [SerializeField] AudioSource bgmSource;   // Loop ? Output = BGM
        [SerializeField] AudioSource sfxSource;   // Output = SFX
        [SerializeField] AudioClip menuBgm;
        [SerializeField] AudioClip stageBgm;

        void Awake()
        {
            if (Instance != null) { Destroy(gameObject); return; }
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
            ApplySaved();
        }

        void Start()
        {
            if (Instance == this && !bgmSource.isPlaying)
                OnSceneLoaded(SceneManager.GetActiveScene(), LoadSceneMode.Single);
        }

        void OnDestroy()
        {
            if (Instance == this) SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            bool isStage = scene.name == "Stage1" || scene.name == "Stage2";
            AudioClip clip = isStage ? stageBgm : menuBgm;
            if (clip == null) return;
            if (bgmSource.clip == clip && bgmSource.isPlaying) return;
            bgmSource.clip = clip;
            bgmSource.Play();
        }

        public void PlaySFX(AudioClip clip)
        {
            if (clip != null) sfxSource.PlayOneShot(clip);
        }

        public void SetBGM(float v)
        {
            mixer.SetFloat("BGMVolume", Mathf.Log10(Mathf.Clamp(v, 0.0001f, 1f)) * 20f);
            PlayerPrefs.SetFloat("BGM", v);
        }

        public void SetSFX(float v)
        {
            mixer.SetFloat("SFXVolume", Mathf.Log10(Mathf.Clamp(v, 0.0001f, 1f)) * 20f);
            PlayerPrefs.SetFloat("SFX", v);
        }

        void ApplySaved()
        {
            SetBGM(PlayerPrefs.GetFloat("BGM", 0.8f));
            SetSFX(PlayerPrefs.GetFloat("SFX", 0.8f));
        }
    }
}