using UnityEngine;

public class GYMMechanic : MonoBehaviour
{
    [SerializeField] private FatigueMechanic fatigueMechanic;
    [SerializeField] private TimeScript timeScript;

    public void Train() {
        fatigueMechanic.setFatigue(fatigueMechanic.getFatigue() + PlayerPrefs.GetInt("FatiguePercentage", -1));
        timeScript.addTime(10);
    }
}