using System.Linq;
using TMPro;
using UnityEngine;

public class TextValidator : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;

    void Start()
    {
        inputField.onValueChanged.AddListener(UpdateText);  
    }

    void UpdateText(string text)
    {
        string newText = new string(text.Where(c => char.IsDigit(c)).ToArray());
        if (newText != text) {
            inputField.text = newText;
        }
    }
}
