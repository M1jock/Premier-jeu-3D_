using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ToolBox
{
    public static string ConvertSecondToMinuteAndSecond(float seconds)
    {
        int hours = (int) (seconds / 3600f);
        int minutes = (int) (seconds / 60f);
        int secondLeft = (int)(seconds - (minutes*60) - (hours*3600));

        string minutesLeftStr = (minutes < 10) ? "0" + minutes.ToString() : minutes.ToString();
        string secondsLeftStr = (secondLeft < 10) ? "0" + secondLeft.ToString() : secondLeft.ToString();

        if (hours > 0)
        {
            return hours + " hours " + minutesLeftStr + " min " + secondsLeftStr;
        }
        else if(minutes > 0)
        {
            return minutesLeftStr + " min " + secondsLeftStr;
        }
        else
        {
            return secondsLeftStr + " sec ";
        }
    }
}
