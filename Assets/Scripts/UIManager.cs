using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{   
    public Text stopwatch;

    public void TimerUpdate(float timing)
    {   if(timing>=10)
            stopwatch.text = "00: " + timing.ToString();
        else
             stopwatch.text = "00: 0" + timing.ToString();
    }

    public void LevelFailPanel()
    {

    }

    public void LevelCompletePanel()
    {

    }
}
