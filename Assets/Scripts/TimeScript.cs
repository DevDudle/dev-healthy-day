using System.Collections;
using System.IO;
using TMPro;
using UnityEngine;

public class TimeScript : MonoBehaviour
{
    private int hour;
    private int minute;
    private int day;

    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Pause pause;

    void Start() {
        hour = PlayerPrefs.GetInt("Hour", 12);
        minute = PlayerPrefs.GetInt("Minute", 0);
        day = PlayerPrefs.GetInt("Day", 1);
    
        StartCoroutine("Increment");                
    }

    void Update() {
        text.text = $"День {day}. {hour.ToString("00")}:{minute.ToString("00")}";
    }

    IEnumerator Increment() {
        while (true) {
            yield return new WaitForSeconds(1);
            
            if (!pause.GetPaused()) {
                minute++;

                if (minute == 60) {
                    minute = 0;
                    hour++;
                    
                    if (hour == 24) {
                        hour = 0;
                        day++;

                        PlayerPrefs.SetInt("Day", day);
                    }
                }

                PlayerPrefs.SetInt("Hour", hour);
                PlayerPrefs.SetInt("Minute", minute);
            }
        }
    }

    public void addTime(int minutes) {
        minute += minutes;
        while (minute >= 60) {
            hour++;
            if (hour >= 24) {
                hour -= 24;
                day++;
            }

            minute -= 60;

            PlayerPrefs.SetInt("Hour", hour);
            PlayerPrefs.SetInt("Minute", minute);
            PlayerPrefs.SetInt("Day", day);
        }    
    }

    public Vector3 getTime() {
        return new Vector3(day, hour, minute);
    }
}
