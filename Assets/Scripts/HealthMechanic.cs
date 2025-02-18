using System.Collections;
using TMPro;
using UnityEngine;

public class HealthMechanic : MonoBehaviour
{
    [SerializeField] private HungryMechanic hungryMechanic;
    [SerializeField] private FatigueMechanic fatigueMechanic;
    [SerializeField] private TextMeshProUGUI healthLabel;

    private int health;

    void Start() {
        health = PlayerPrefs.GetInt("Health", 100);
        StartCoroutine("Handle");
    }

    void Update() {
        if (health > 100) {
            health = 100;
            PlayerPrefs.SetInt("Health", 100);
        }

        if (health < 0) {
            health = 0;
            PlayerPrefs.SetInt("Health", 0);
            PlayerPrefs.SetInt("GameOver", 1);
        }

        healthLabel.text = $"Здоровье: {health}%";
    }

    IEnumerator Handle() {
        while (true) {            
            if (hungryMechanic.GetHungry() <= 0) {
                health--;
                yield return new WaitForSeconds(1f);
            }
            
            if (fatigueMechanic.getFatigue() > 100) {
                health--;

                fatigueMechanic.setFatigue(100);
                yield return new WaitForSeconds(0.5f);
            } else {
                yield return new WaitForSeconds(2f);
            }
            
            PlayerPrefs.SetInt("Health", health);
        }
    }

    public int getHealth() {
        return health;
    }

    public void setHealth(int newHealth) {
        health = newHealth;
        PlayerPrefs.SetInt("Health", health);
    }
}
