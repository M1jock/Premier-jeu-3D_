using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float seconds;
    public int startMinute;
    public TextMeshProUGUI timerText;

    // Start is called before the first frame update
    void Start()
    {
        seconds = startMinute * 60;
    }

    // Update is called once per frame
    void Update()
    {
        seconds += Time.deltaTime;

        timerText.text = ConvertSecondToMinuteAndSecond(seconds);
    }
    public string ConvertSecondToMinuteAndSecond(float seconds)
    {
        int hours = (int)(seconds / 3600f);
        int minutes = (int)(seconds / 60f);
        int secondLeft = (int)(seconds - (minutes * 60) - (hours * 3600));

        string minutesLeftStr = (minutes < 10) ? "0" + minutes.ToString() : minutes.ToString();
        string secondsLeftStr = (secondLeft < 10) ? "0" + secondLeft.ToString() : secondLeft.ToString();

        if (hours > 0)
        {
            return hours + " h " + minutesLeftStr + " min " + secondsLeftStr;
        }
        else if (minutes > 0)
        {
            return minutes + " min " + secondsLeftStr;
        }
        else
        {
            return seconds + " sec";
        }
    }

}
