using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MixerVolumeChanger : MonoBehaviour
{
    [SerializeField] private Pause pause;
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI text;

    void Start() {
        float volume = PlayerPrefs.GetFloat("Volume", 1.0f);
        if (volume <= 0) volume = 0;

        if (slider) slider.value = volume;
        if (text) text.text = $"Громкость музыки и эффектов: {volume}% ({((volume == 0) ? -100 : (10 * (volume / 20) * 100))}dB)";

        PlayerPrefs.SetFloat("Volume", volume);
        mixer.SetFloat("MasterVolume", volume);
    }
    
    void Update() {
        if (pause.GetPaused()) {
            mixer.SetFloat("MasterVolume", -80f);
        } else {
            float volume = PlayerPrefs.GetFloat("Volume", 1.0f);
            mixer.SetFloat("MasterVolume", Mathf.Log10((volume / 100)) * 20);
        }
    }

    public void SetVolume(float newVolume)
    {
        int percentage = (int)newVolume;
        if (newVolume <= 0) {
            newVolume = 0.001F;
        }

        newVolume = Mathf.Log10((newVolume / 100)) * 20;

        text.text = $"Громкость музыки и эффектов: {percentage}% ({Mathf.RoundToInt(newVolume)}dB)";

        mixer.SetFloat("MasterVolume", newVolume);
        PlayerPrefs.SetFloat("Volume", newVolume);
    }
}
