using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI Text;
    [SerializeField] private int sceneNumber;

    public void Change() {
        StartCoroutine("Handle");
    }

    IEnumerator Handle() {
        PlayerPrefs.SetInt("PrevScene", SceneManager.GetActiveScene().buildIndex);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneNumber);
        
        float progress;
        while (!operation.isDone) {
            panel.SetActive(true);
            progress = operation.progress;
            Text.SetText($"Загрузка.. {(progress * 100).ToString("0")}%");
            yield return null;
        }
    }
}
