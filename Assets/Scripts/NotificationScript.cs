using System.Collections;
using TMPro;
using UnityEngine;

public class NotificationScript : MonoBehaviour
{
    [SerializeField] public string title;
    [SerializeField] public string message;
    [SerializeField] public GameObject prefab;
    [SerializeField] public Transform parent;

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
        
        if (parent.childCount > 1) {
            for (int i = parent.childCount - 1; i >= 0; i--) {
                Destroy(parent.GetChild(i).gameObject);
                yield return new WaitForSeconds(3.5f);
            }
        } else {
            Destroy(notification);
        }
    }
}
