using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPositionSetter : MonoBehaviour
{
    [SerializeField] private List<Button> buttons;
    [SerializeField] private int buttonHeight, offset;

    void Start()
    {
        int count = (buttons.Count % 2 != 0 ? -1 : 0);
        foreach (Button button in buttons) {
            RectTransform rectT = button.GetComponent<RectTransform>();
            rectT.localPosition = new Vector3(0, -((buttonHeight + offset) * count), 0);

            count++;
        }
    }
}
