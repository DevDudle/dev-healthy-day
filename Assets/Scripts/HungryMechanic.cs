using System.Collections;
using TMPro;
using UnityEngine;

public class HungryMechanic : MonoBehaviour
{
    private int hungryPercentage;
    [SerializeField] private FineMechanic fineMechanic;
    [SerializeField] private TextMeshProUGUI text; 
    [SerializeField] private Pause pause;

    void Start()
    {
        hungryPercentage = PlayerPrefs.GetInt("HungryPercentage", 100);
        StartCoroutine("Handle");
    }

    void Update() {
        if (hungryPercentage > 100) {
            hungryPercentage = 100;
            PlayerPrefs.SetInt("HungryPercentage", 100);
        }

        if (hungryPercentage < 0) {
            hungryPercentage = 0;
            PlayerPrefs.SetInt("HungryPercentage", 0);
        }

        text.text = $"Сытость: {hungryPercentage}%";
    }

    IEnumerator Handle() {
        while (true) {
            if (hungryPercentage < 0) {
                hungryPercentage = 0;
            }

            if (!pause.GetPaused()) {
                yield return new WaitForSeconds(30);

                hungryPercentage -= (100 - fineMechanic.GetFine() <= 40 && 100 - fineMechanic.GetFine() > 0 ? 3 : 1);
                if (hungryPercentage <= 0) {
                    hungryPercentage = 0;
                }

                PlayerPrefs.SetInt("HungryPercentage", hungryPercentage);
            }
        }
    }

    public int GetHungry() {
        return hungryPercentage;
    }

    public void setHungry(int newHungry) {
        hungryPercentage = newHungry;
        PlayerPrefs.SetInt("HungryPercentage", newHungry);
    }

    public void Reset() {
        hungryPercentage = 100;
        PlayerPrefs.SetInt("HungryPercentage", 100);
    }
}
