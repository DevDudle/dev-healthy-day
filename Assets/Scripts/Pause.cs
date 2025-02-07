using UnityEngine;

public class Pause : MonoBehaviour
{
    private bool isPaused;

    [SerializeField] private GameObject pauseObject;

    void Start() {
        UnPause();
    }

    void Update() {
        if (Input.GetKeyUp(KeyCode.Escape) || PlayerPrefs.GetInt("UnPause", 0) == 1) {
            PlayerPrefs.SetInt("UnPause", 0);
            Handle();
        }
    }

    void Handle() {
        if (!isPaused) {
            pauseObject.SetActive(true);
            Time.timeScale = 0;
        } else {
            pauseObject.SetActive(false);
            Time.timeScale = 1;
        }

        isPaused = !isPaused;
    }

    public bool GetPaused() {
        return isPaused;
    }

    public void UnPause() {
        Time.timeScale = 1;
    }
}
