using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuyConfirmScript : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private string objname;
    [SerializeField] private int cost;
    [SerializeField] private int health;
    [SerializeField] private int hungry;

    public void OnPointerClick(PointerEventData pointerEventData) {
        panel.SetActive(true);
        description.text = $"Название: {objname}. Цена: {cost}руб., {((health > 0) ? $"+{health}" : health)}% здоровья, +{hungry}% сытости";
        
        PlayerPrefs.SetInt("CurrentCost", cost);
        PlayerPrefs.SetInt("CurrentHealth", health);
        PlayerPrefs.SetInt("CurrentHungry", hungry);
        
        //Debug.Log($"{PlayerPrefs.GetInt("CurrentCost")}, {PlayerPrefs.GetInt("CurrentHealth")}, {PlayerPrefs.GetInt("CurrentHungry")}");
    }
}
