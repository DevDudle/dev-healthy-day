using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class BuyScript : MonoBehaviour
{
    [SerializeField] private Economy economy;
    [SerializeField] private HungryMechanic hungryMechanic;
    [SerializeField] private HealthMechanic healthMechanic;

    public void Buy() {
        if (economy.getBalance() >= PlayerPrefs.GetInt("CurrentCost", -1) && hungryMechanic.GetHungry() + PlayerPrefs.GetInt("CurrentHungry", -1) <= 100) {
            economy.setBalance(economy.getBalance() - PlayerPrefs.GetInt("CurrentCost", -1));
            hungryMechanic.setHungry(hungryMechanic.GetHungry() + PlayerPrefs.GetInt("CurrentHungry", -1));
            healthMechanic.setHealth(healthMechanic.getHealth() + PlayerPrefs.GetInt("CurrentHealth", -1));
        }
    }
}
