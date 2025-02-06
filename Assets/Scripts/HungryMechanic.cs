using System.Collections;
using TMPro;
using UnityEngine;

public class HungryMechanic : MonoBehaviour
{
    private int hungryPercentage;
    [SerializeField] private TextMeshProUGUI text; 
    [SerializeField] private Pause pause;

    void Start()
    {
        hungryPercentage = PlayerPrefs.GetInt("HungryPercentage", 100);
        StartCoroutine("Handle");

        text.text = $"Голод: {hungryPercentage}%";
    }

    IEnumerator Handle() {
        while (true) {
            if (hungryPercentage < 0) {
                hungryPercentage = 0;
            }

            if (!pause.GetPaused()) {
                yield return new WaitForSeconds(30);

                hungryPercentage--;
                if (hungryPercentage <= 0) {
                    hungryPercentage = 0;
                }

                PlayerPrefs.SetInt("HungryPercentage", hungryPercentage);
                text.text = $"Голод: {hungryPercentage}%";
            }
        }
    }

    public int GetHungry() {
        return hungryPercentage;
    }

    public void setHungry(int newHungry) {
        hungryPercentage = newHungry;

        PlayerPrefs.SetInt("HungryPercentage", newHungry);
        text.text = $"Голод: {hungryPercentage}%";
    }

    public void Reset() {
        hungryPercentage = 100;
        PlayerPrefs.SetInt("HungryPercentage", 100);
        text.text = $"Голод: {hungryPercentage}%";
    }
}
