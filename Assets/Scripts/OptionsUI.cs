using UnityEngine;
using UnityEngine.UI;

namespace chadsadaporn_babpa.Exam
{
    public class OptionsUI : MonoBehaviour
    {
        [SerializeField] Slider bgmSlider;
        [SerializeField] Slider sfxSlider;

        void Start()
        {
            bgmSlider.SetValueWithoutNotify(PlayerPrefs.GetFloat("BGM", 0.8f));
            sfxSlider.SetValueWithoutNotify(PlayerPrefs.GetFloat("SFX", 0.8f));

            bgmSlider.onValueChanged.AddListener(v =>
            {
                if (AudioManager.Instance != null) AudioManager.Instance.SetBGM(v);
            });
            sfxSlider.onValueChanged.AddListener(v =>
            {
                if (AudioManager.Instance != null) AudioManager.Instance.SetSFX(v);
            });
        }
    }
}