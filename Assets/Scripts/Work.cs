using UnityEngine;

public class Work : MonoBehaviour
{
    [SerializeField] private TimeScript timeScript;
    [SerializeField] private HungryMechanic hungryMechanic;
    [SerializeField] private FineMechanic fineMechanic;
    [SerializeField] private Economy economy;

    public void getSalary() {
        if (PlayerPrefs.GetInt("Hour") >= 8 && PlayerPrefs.GetInt("Hour") <= 17) {
            economy.setBalance(economy.getBalance() + Random.Range(50, 200));
            timeScript.addTime((int)(1.5 * 60));
            fineMechanic.setFine((int)fineMechanic.GetFine() - Random.Range(1, (int)(fineMechanic.GetFine() / 4)));
            hungryMechanic.setHungry((int)hungryMechanic.GetHungry() - Random.Range(1, (int)(hungryMechanic.GetHungry() / 4)));
        }
    }
}
