using UnityEngine;

public class SaveData : MonoBehaviour
{
    [SerializeField] private HealthMechanic healthMechanic;
    [SerializeField] private FineMechanic fineMechanic;
    [SerializeField] private HungryMechanic hungryMechanic;
    [SerializeField] private Economy economy;
    [SerializeField] private TimeScript timeScript;

    public void Handle() {
        PlayerPrefs.SetInt("Health", healthMechanic.getHealth());
        PlayerPrefs.SetInt("FinePercentage", fineMechanic.GetFine());
        PlayerPrefs.SetInt("HungryPercentage", hungryMechanic.GetHungry());
        PlayerPrefs.SetInt("Balance", economy.getBalance());
        PlayerPrefs.SetInt("Day", (int)timeScript.getTime()[0]);
        PlayerPrefs.SetInt("Hour", (int)timeScript.getTime()[1]);
        PlayerPrefs.SetInt("Minute", (int)timeScript.getTime()[2]);
    }
}
