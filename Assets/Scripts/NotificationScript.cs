using System.Collections;
using TMPro;
using UnityEditor.Tilemaps;
using UnityEngine;

public class NotificationScript : MonoBehaviour
{
    [SerializeField] private string title;
    [SerializeField] private string message;
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform parent;

    private GameObject notification;

    public void Notificate() {
        notification = Instantiate(prefab);
        notification.transform.SetParent(parent);

        RectTransform rectTransform = notification.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, 0, 0);
        rectTransform.localRotation = Quaternion.Euler(0, 0, 0);
        rectTransform.localScale = new Vector3(1, 1, 1);
        rectTransform.offsetMin = new Vector2(0, 0);
        rectTransform.offsetMax = new Vector2(0, 0);

        TextMeshProUGUI[] textObjects = notification.GetComponentsInChildren<TextMeshProUGUI>();

        TextMeshProUGUI titleObject = textObjects[0];
        TextMeshProUGUI messageObject = textObjects[1];

        titleObject.text = title;
        messageObject.text = message;

        StartCoroutine("DeleteNotification");
    }

    IEnumerator DeleteNotification() {
        yield return new WaitForSeconds(3.5f);
        Destroy(notification);
    }
}
