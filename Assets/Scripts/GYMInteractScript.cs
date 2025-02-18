using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class GYMInteractScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private GameObject interactPanel;
    [SerializeField] private TextMeshProUGUI actionText;
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private string text;
    [SerializeField] private string titleText;
    [SerializeField] private GameObject actionPanel;
    [SerializeField] private int fatiguePercentage;
    [SerializeField] private GYMMechanic gymMechanic;

    public void OnPointerEnter(PointerEventData eventData)
    {
        actionText.text = text;
        interactPanel.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        interactPanel.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData) 
    {
        title.text = titleText;
        actionPanel.SetActive(true);

        PlayerPrefs.SetInt("FatiguePercentage", fatiguePercentage);
    }
}