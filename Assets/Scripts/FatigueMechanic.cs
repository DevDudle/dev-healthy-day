using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FatigueMechanic : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI fatigueLabel;
    [SerializeField] private Pause pause;

    private int fatigue;

    void Start() {
        fatigue = PlayerPrefs.GetInt("Fatigue", 0);
        
        fatigueLabel.text = $"Утомление: {fatigue}%";
    }

    public int getFatigue() {
        return fatigue;
    }

    public void setFatigue(int newFatigue) {
        fatigue = newFatigue;
        if (fatigue > 100) fatigue = 100;

        PlayerPrefs.SetInt("Fatigue", fatigue);

        fatigueLabel.text = $"Утомление: {fatigue}%";
    }
}
