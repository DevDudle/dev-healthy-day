using UnityEngine;

public class Sleep : MonoBehaviour
{
    [SerializeField] private TimeScript timeScript;
    [SerializeField] private FatigueMechanic fatigueMechanic;

    public void Handle() {
        if ((PlayerPrefs.GetInt("Hour") <= 6 || PlayerPrefs.GetInt("Hour") >= 20) || fatigueMechanic.getFatigue() >= 50) {
            timeScript.addTime(2 * 60);
            fatigueMechanic.setFatigue(fatigueMechanic.getFatigue() - 25);
        }
    }
}
