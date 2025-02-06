using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class LaptopInteractScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private GameObject interactPanel;
    [SerializeField] private TextMeshProUGUI actionText;
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private string text;
    [SerializeField] private string titleText;
    [SerializeField] private GameObject actionPanel;

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
    }
}