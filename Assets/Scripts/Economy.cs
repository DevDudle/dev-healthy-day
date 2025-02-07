using TMPro;
using UnityEngine;

public class Economy : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI balanceLabel;
    private int balance; 

    void Start() {
        balance = PlayerPrefs.GetInt("Balance", 1000);
    }

    void Update() {
        balanceLabel.text = $"Баланс: {balance}руб.";
    }

    public int getBalance() {
        return balance;
    }

    public void setBalance(int newBalance) {
        balance = newBalance;
        PlayerPrefs.SetInt("Balance", balance);
    }
}
