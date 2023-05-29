using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace UI
{
    public class MusicSettings : MonoBehaviour
    {
        [SerializeField] private GameObject mainPanel;
        [SerializeField] private UISwitcher uISwitcher;

        [SerializeField] private Button settingsButton;
        [SerializeField] private Button settingsBackButton;

        [SerializeField] private Slider musicSlider;
        [SerializeField] private Slider sfxSlider;

        [SerializeField] private AudioMixer mixer;

        private const string MUSIC_VOLUME = "MUSIC_VOLUME";
        private const string SFX_VOLUME = "SFX_VOLUME";

        private void Start()
        {
            Load();
            Bind();
        }

        private void OnDisable()
        {
            PlayerPrefs.SetFloat(MUSIC_VOLUME, musicSlider.value);
            PlayerPrefs.SetFloat(SFX_VOLUME, sfxSlider.value);
        }

        private void Load()
        {
            musicSlider.value = PlayerPrefs.GetFloat(MUSIC_VOLUME, 1f);
            sfxSlider.value = PlayerPrefs.GetFloat(SFX_VOLUME, 1f);

            SetMusicVolume(musicSlider.value);
            SetSfxVolume(sfxSlider.value);
        }

        private void Bind()
        {
            gameObject.SetActive(false);

            musicSlider.onValueChanged.AddListener(SetMusicVolume);
            sfxSlider.onValueChanged.AddListener(SetSfxVolume);

            settingsButton.onClick.AddListener(() => uISwitcher.TurnOnPanel(gameObject));
            settingsBackButton.onClick.AddListener(() => uISwitcher.TurnOnPanel(mainPanel));
        }

        private void SetMusicVolume(float value)
        {
            mixer.SetFloat(MUSIC_VOLUME, Mathf.Log10(value) * 20);
        }

        private void SetSfxVolume(float value)
        {
            mixer.SetFloat(SFX_VOLUME, Mathf.Log10(value) * 20);
        }
    }
}