using System.Collections;
using UnityEngine;

public class ShowObject : MonoBehaviour
{
    [SerializeField] private GameObject obj;

    void Start() {
        StartCoroutine("ShowAfter5sec");
    }

    IEnumerator ShowAfter5sec() {
        yield return new WaitForSeconds(5);
        obj.SetActive(true);
    }
}
