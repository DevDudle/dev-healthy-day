using UnityEngine;

public class Pause : MonoBehaviour
{
    private bool isPaused;

    [SerializeField] private GameObject pauseObject;

    void Update() {
        if (Input.GetKeyUp(KeyCode.Escape)) {
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
}
