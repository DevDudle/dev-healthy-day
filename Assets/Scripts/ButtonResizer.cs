using UnityEngine;
using UnityEngine.UI;

public class ButtonResizer : MonoBehaviour
{
    [SerializeField] private Button button;

    void Update()
    {
        double width = Screen.currentResolution.width / 3.2;
        double height = width / 4;
    
        RectTransform rectT = button.GetComponent<RectTransform>();
        rectT.sizeDelta = new Vector2((float)width, (float)height);
    }
}
