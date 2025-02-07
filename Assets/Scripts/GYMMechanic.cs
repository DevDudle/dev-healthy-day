using UnityEngine;

public class GYMMechanic : MonoBehaviour
{
    [SerializeField] private FatigueMechanic fatigueMechanic;
    [SerializeField] private FineMechanic fineMechanic;
    [SerializeField] private TimeScript timeScript;

    public void Train() {
        if ((PlayerPrefs.GetInt("Hour") >= 7 && PlayerPrefs.GetInt("Hour") <= 22) && (fatigueMechanic.getFatigue() + PlayerPrefs.GetInt("FatiguePercentage", -1) <= 100)) {
            fatigueMechanic.setFatigue(fatigueMechanic.getFatigue() + PlayerPrefs.GetInt("FatiguePercentage", -1));
            fineMechanic.setFine(fineMechanic.GetFine() + PlayerPrefs.GetInt("FatiguePercentage", -1));
            timeScript.addTime(10);
        }
    }
}