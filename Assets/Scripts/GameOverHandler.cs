using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI Text;

    public void Change(bool GameOver) {
        StartCoroutine("Handle", GameOver);
    }

    IEnumerator Handle(bool GameOver) {
        AsyncOperation operation = SceneManager.LoadSceneAsync(GameOver ? SceneManager.sceneCountInBuildSettings - 2 : SceneManager.sceneCountInBuildSettings - 1);
        
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
        if (PlayerPrefs.GetInt("GameOver", 0) == 1 || PlayerPrefs.GetInt("Day", 0) == 8) {
            PlayerPrefs.SetInt("FinePercentage", 100);
            PlayerPrefs.SetInt("HungryPercentage", 100);
            PlayerPrefs.SetInt("Health", 100);
            PlayerPrefs.SetInt("Fatigue", 0);
            PlayerPrefs.SetInt("Day", 1);
            PlayerPrefs.SetInt("Hour", 12);
            PlayerPrefs.SetInt("Minute", 0);
            PlayerPrefs.SetInt("GameOver", 0);

            Change(PlayerPrefs.GetInt("GameOver", 0) == 1 ? true : false);
        }
    }
}
