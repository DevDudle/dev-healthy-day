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
        Debug.Log("FStart0");
        fatigue = PlayerPrefs.GetInt("Fatigue", 0);
        
        fatigueLabel.text = $"Утомление: {fatigue}%";
        StartCoroutine("Handle");
    }

    IEnumerator Handle() {
        while (true) {
            if (!pause.GetPaused() && SceneManager.GetActiveScene().buildIndex == 3) {
                yield return new WaitForSeconds(2);
                
                fatigue++;
                PlayerPrefs.SetInt("Fatigue", fatigue);
                
                fatigueLabel.text = $"Утомление: {fatigue}%";
            } else if (!pause.GetPaused()) {
                yield return new WaitForSeconds(0.01f);
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
