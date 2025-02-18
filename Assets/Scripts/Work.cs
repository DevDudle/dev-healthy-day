using System.IO.Compression;
using UnityEngine;
using UnityEngine.Playables;

public class Work : MonoBehaviour
{
    [SerializeField] private TimeScript timeScript;
    [SerializeField] private HungryMechanic hungryMechanic;
    [SerializeField] private FineMechanic fineMechanic;
    [SerializeField] private FatigueMechanic fatigueMechanic;
    [SerializeField] private Economy economy;
    [SerializeField] private Transform parent;

    public void getSalary() {
        if (PlayerPrefs.GetInt("Hour") >= 8 && PlayerPrefs.GetInt("Hour") <= 17 && fatigueMechanic.getFatigue() + 10 <= 100) {
            int salary = Random.Range(50, 200);
            economy.setBalance(economy.getBalance() + salary);
            
            NotificationScript notificationScript = parent.GetComponent<NotificationScript>();
            notificationScript.title = "Ноутбук";
            notificationScript.message = $"Вы поработали! +{salary} рублей!";
            notificationScript.parent = parent;
            notificationScript.Notificate();

            timeScript.addTime((int)(1.5 * 60));
            fatigueMechanic.setFatigue(fatigueMechanic.getFatigue() + 10);
            fineMechanic.setFine((int)fineMechanic.GetFine() - Random.Range(1, (int)(fineMechanic.GetFine() / 4)));
            hungryMechanic.setHungry((int)hungryMechanic.GetHungry() - Random.Range(1, (int)(hungryMechanic.GetHungry() / 4)));
        } else if (fatigueMechanic.getFatigue() + 10 > 100) {
            ShowNotification("Ноутбук", "Вы слишком устали для работы! Вам необходимо отдохнуть!");
        } else {
            ShowNotification("Ноутбук", "Работать можно только с 8 до 18 часов! Пожалуйста, подождите и повторите попытку...");
        }
    }

    private void ShowNotification(string title, string message) {
        NotificationScript notificationScript = parent.GetComponent<NotificationScript>();
        if (notificationScript != null)
        {
            notificationScript.title = title;
            notificationScript.message = message;
            notificationScript.parent = parent;
            notificationScript.Notificate();
        }
    }
}
