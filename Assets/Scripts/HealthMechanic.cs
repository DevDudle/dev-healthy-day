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
                
        healthLabel.text = $"Здоровье: {health}%";
    }

    IEnumerator Handle() {
        while (true) {            
            if (hungryMechanic.GetHungry() <= 0) {
                health--;
                healthLabel.text = $"Здоровье: {health}%";
                
                yield return new WaitForSeconds(1f);
            }
            
            if (fatigueMechanic.getFatigue() > 100) {
                health--;
             
                if (health <= 0) {
                    PlayerPrefs.SetInt("GameOver", 1);
                }
             
                healthLabel.text = $"Здоровье: {health}%";

                fatigueMechanic.setFatigue(100);
                yield return new WaitForSeconds(0.5f);
            } else {
                yield return new WaitForSeconds(2f);
            }
        }
    }

    public int getHealth() {
        return health;
    }
}
