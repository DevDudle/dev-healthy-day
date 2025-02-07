using System.Collections;
using TMPro;
using UnityEngine;

public class FatigueMechanic : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI fatigueLabel;
    [SerializeField] private Pause pause;

    private int fatigue;

    void Start() {
        fatigue = PlayerPrefs.GetInt("Fatigue", 0);
    }

    void Update() {
        if (fatigue > 100) {
            fatigue = 100;
            PlayerPrefs.SetInt("Fatigue", 100);
        }

        if (fatigue < 0) {
            fatigue = 0;
            PlayerPrefs.SetInt("Fatigue", 0);
        }

        fatigueLabel.text = $"Утомление: {fatigue}%";
    }

    IEnumerator Handle() {
        while (true) {
            if (!pause.GetPaused()) {
                yield return new WaitForSeconds(120);

                fatigue++;
                PlayerPrefs.SetInt("Fatigue", fatigue);
            }
        }
    }

    public int getFatigue() {
        return fatigue;
    }

    public void setFatigue(int newFatigue) {
        fatigue = newFatigue;
        PlayerPrefs.SetInt("Fatigue", fatigue);
    }
}
