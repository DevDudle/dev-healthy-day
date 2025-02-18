using UnityEngine;

public class Sleep : MonoBehaviour
{
    [SerializeField] private TimeScript timeScript;
    [SerializeField] private FatigueMechanic fatigueMechanic;
    [SerializeField] private Transform parent;

    public void Handle() {
        if ((PlayerPrefs.GetInt("Hour") <= 6 || PlayerPrefs.GetInt("Hour") >= 20) || fatigueMechanic.getFatigue() >= 50) {
            timeScript.addTime(2 * 60);
            fatigueMechanic.setFatigue(fatigueMechanic.getFatigue() - 25);
        } else {
            ShowNotification("Кровать", "Не время спать! Вы в расцвете сил. Попробуйте устать или дождаться 20 часов и повторить попытку...");
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
