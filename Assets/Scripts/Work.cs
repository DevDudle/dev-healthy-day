using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Work : MonoBehaviour
{
    [SerializeField] private TimeScript timeScript;
    [SerializeField] private HungryMechanic hungryMechanic;
    [SerializeField] private FineMechanic fineMechanic;
    [SerializeField] private FatigueMechanic fatigueMechanic;
    [SerializeField] private Economy economy;
    [SerializeField] private Transform parent;
    [SerializeField] private GameObject minigamePanel;
    [SerializeField] private TextMeshProUGUI component;
    [SerializeField] private TMP_InputField userAnswer;
        
    public int first, second, third;

    void UpdateNumbers()
    {
        first = Random.Range(1, 10);
        second = Random.Range(1, 10);
        third = Random.Range(1, 10);

        PlayerPrefs.SetInt("Answer", first + (second * third));
    }

    public void tryToWork() {
        if (PlayerPrefs.GetInt("Hour") >= 8 && PlayerPrefs.GetInt("Hour") <= 17 && fatigueMechanic.getFatigue() + 10 <= 100) {
            UpdateNumbers();
            ShowMinigame();
        } else if (fatigueMechanic.getFatigue() + 10 > 100) {
            ShowNotification("Ноутбук", "Вы слишком устали для работы! Вам необходимо отдохнуть!");
        } else {
            ShowNotification("Ноутбук", "Работать можно только с 8 до 18 часов! Пожалуйста, подождите и повторите попытку...");
        }
    }

    public void getSalary() {
        NotificationScript notificationScript = parent.GetComponent<NotificationScript>();
        notificationScript.title = "Ноутбук";
        
        int parsedans = int.Parse(userAnswer.text);
        int ans = PlayerPrefs.GetInt("Answer", -1);
        bool isCorrect = ans == parsedans;
        
        int salary = isCorrect ? Random.Range(75, 100) : Random.Range(1, 25);
        economy.setBalance(economy.getBalance() + salary);

        notificationScript.message = isCorrect 
            ? $"Вы поработали! +{salary} рублей!" 
            : $"Вы плохо работали! +{salary} рублей!";

        notificationScript.parent = parent;
        notificationScript.Notificate();

        timeScript.addTime((int)(1.5 * 60));
        fatigueMechanic.setFatigue(fatigueMechanic.getFatigue() + 10);
        fineMechanic.setFine((int)fineMechanic.GetFine() - Random.Range(1, (int)(fineMechanic.GetFine() / 4)));
        hungryMechanic.setHungry((int)hungryMechanic.GetHungry() - Random.Range(1, (int)(hungryMechanic.GetHungry() / 4)));

        minigamePanel.SetActive(false);
    }

    void ShowMinigame() {
        minigamePanel.SetActive(true);
        component.text = first + " + " + second + " * " + third + " = ";
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
