using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerRule
{
    public int t1;
    public int t2;
    public int t3;
}

[System.Serializable]
public class TimerList
{
    public List<TimerRule> rule;
}


public class RulesManager : MonoBehaviour
{   

    private TimerList timerlist;
    
    public float[] timers = {45f,30f,20f};
    public int counter=0;

    private UIManager UIObj;

   void Start()
    {   
        //Aimed at extending to new levels

        //timerlist = JsonUtility.FromJson<TimerList>("");


        UIObj = GameObject.Find("UI").GetComponent<UIManager>();
        SpawnExplosive();
        InitTimer();
    }

    void Update()
    {
        
    }

    public void InitTimer()
    {
        StartCoroutine(SetStopWatch(timers[counter]));
    }

    public void SpawnExplosive()
    {

    }

    private IEnumerator SetStopWatch(float countdownValue)
    {   
        float currCountdownValue = countdownValue;
        
        while (currCountdownValue > 0)
        {
            Debug.Log("Countdown: " + currCountdownValue);
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;

            UIObj.TimerUpdate(currCountdownValue);
        }

        if(currCountdownValue==0)
        {
            EndGame();
        }
    }


    private void EndGame()
    {
        UIObj.LevelFailPanel();
    }
}
