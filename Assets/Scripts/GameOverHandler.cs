using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI Text;
    [SerializeField] private HealthMechanic healthMechanic;

    public void Change(bool GameOver) {
        StartCoroutine("Handle", GameOver);
    }

    IEnumerator Handle(bool GameOver) {
        AsyncOperation operation = SceneManager.LoadSceneAsync(GameOver ? SceneManager.sceneCountInBuildSettings - 2 : SceneManager.sceneCountInBuildSettings - 1);
        Debug.Log((GameOver ? SceneManager.sceneCountInBuildSettings - 2 : SceneManager.sceneCountInBuildSettings - 1).ToString());
        
        float progress;
        while (!operation.isDone) {
            panel.SetActive(true);
            progress = operation.progress;
            Text.SetText($"Загрузка.. {(progress * 100).ToString("0")}%");
            yield return null;
        }
    }

    void Update()
    {
        if (healthMechanic.getHealth() <= 0 || PlayerPrefs.GetInt("Day", 0) == 8) {
            PlayerPrefs.SetInt("Balance", 1000);
            PlayerPrefs.SetInt("FinePercentage", 100);
            PlayerPrefs.SetInt("HungryPercentage", 100);
            PlayerPrefs.SetInt("Health", 100);
            PlayerPrefs.SetInt("Fatigue", 0);
            PlayerPrefs.SetInt("Day", 1);
            PlayerPrefs.SetInt("Hour", 12);
            PlayerPrefs.SetInt("Minute", 0);

            Debug.Log(healthMechanic.getHealth());
            Change(healthMechanic.getHealth() <= 0 ? true : false);
        }
    }
}
