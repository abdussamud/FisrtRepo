using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeHandler : MonoBehaviour
{
    public static TimeHandler Instance;
    public Text Showtime,WatchTime;
    public float timeLeft,WatchTimeLeft;
    public bool TimeCompleteFlag;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        //if(GameManager.Instance.GMode==0)
        //{
        //    timeLeft = GamePlayHandler.Instance.levelmode1[GamePlayHandler.Instance.LevelNum].time;
        //}
        //else if (GameManager.Instance.GMode == 1)
        //{
        //    timeLeft = GamePlayHandler.Instance.levelmode2[GamePlayHandler.Instance.LevelNum].time;
        //}
        //else if (GameManager.Instance.GMode == 2)
        //{
        //    timeLeft = GamePlayHandler.Instance.levelmode3[GamePlayHandler.Instance.LevelNum].time;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        WatchTimeLeft -= Time.deltaTime;
        string minutes = Mathf.Floor(timeLeft / 60).ToString("00");
        string seconds = (timeLeft % 60).ToString("00");
        string secondsWatch = (WatchTimeLeft % 60).ToString("0");
        Showtime.text = string.Format("{0}:{1}", minutes, seconds);
        WatchTime.text = string.Format("{0}", secondsWatch);
        if (!GameManager.Instance.ContinueCheck)
        {
            if (timeLeft < 0)
            {
                timeLeft = 999;
                UIManager.Instance.ActivateTimesUp();
            }
        }
        else
        {
            if (timeLeft < 0)
            {
                timeLeft = 999;
                UIManager.Instance.LevelFailedActivate();
            }
        }
    }
}
