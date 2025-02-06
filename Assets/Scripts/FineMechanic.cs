using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FineMechanic : MonoBehaviour
{
    private int finePercentage;
    [SerializeField] private TextMeshProUGUI text; 
    [SerializeField] private Pause pause;
    [SerializeField] private HungryMechanic hungryMechanic;

    private int sceneNumber;

    void Start()
    {
        finePercentage = PlayerPrefs.GetInt("FinePercentage", 100);

        sceneNumber = SceneManager.GetActiveScene().buildIndex;
        
        StartCoroutine("Handle");
        text.text = $"Счастье: {finePercentage}%";
    }

    IEnumerator Handle() {
        while (true) {
            if (finePercentage < 0) {
                finePercentage = 0;
            }

            if (!pause.GetPaused()) {
                yield return new WaitForSeconds(10);

                PlayerPrefs.SetInt("FinePercentage", finePercentage);
                text.text = $"Счастье: {finePercentage}%";
            }
        }
    }

    public int GetFine() {
        return finePercentage;
    }

    public void setFine(int newFine) {
        finePercentage = newFine;
        PlayerPrefs.SetInt("FinePercentage", newFine);

        text.text = $"Счастье: {finePercentage}%";
    }

    public void Reset() {
        finePercentage = 100;
        PlayerPrefs.SetInt("FinePercentage", 100);
        text.text = $"Счастье: {finePercentage}%";
    }
}
