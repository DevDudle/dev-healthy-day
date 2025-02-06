using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MixerVolumeChanger : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI text;

    void Start() {
        float volume = PlayerPrefs.GetFloat("Volume", 1.0f);

        if (slider) slider.value = volume;
        if (text) text.text = $"Громкость музыки и эффектов: {volume}% ({10 * (volume / 20) * 100}dB)";

        mixer.SetFloat("MasterVolume", volume);
    }

    public void SetVolume(float newVolume)
    {
        int percentage = (int)newVolume;
        if (newVolume == 0) {
            newVolume = 0.001F;
        }

        newVolume = Mathf.Log10((newVolume / 100)) * 20;

        text.text = $"Громкость музыки и эффектов: {percentage}% ({Mathf.RoundToInt(newVolume)}dB)";

        mixer.SetFloat("MasterVolume", newVolume);
        PlayerPrefs.SetFloat("Volume", newVolume);
    }
}
