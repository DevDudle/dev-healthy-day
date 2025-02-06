using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI Text;

    public void Change() {
        StartCoroutine("Handle");
    }

    IEnumerator Handle() {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.sceneCountInBuildSettings - 1);
        
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
        if (PlayerPrefs.GetInt("GameOver") == 1) {
            PlayerPrefs.SetInt("FinePercentage", 100);
            PlayerPrefs.SetInt("HungryPercentage", 100);
            PlayerPrefs.SetInt("Health", 100);
            PlayerPrefs.SetInt("Fatigue", 0);
            PlayerPrefs.SetInt("GameOver", 0);

            Change();
        }
    }
}
