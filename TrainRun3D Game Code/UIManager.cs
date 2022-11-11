using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public Text ERW,ERL, TotalW,TotalL;
    public GameObject CompletePanal, TimesUP, LevelFail, PausePanal;
    public bool WatchFlag;
    public GameObject[] GamePlayButtons;
    public GameData Gdata;
    public int Total;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    private void Start()
    {
        Total = 0;
    }
    
    public void WatchVideo()
    { 
        
    }
    public void WinnigPanalActivate()
    {
        CompletePanal.SetActive(true);
        GamePlayHandler.Instance.DeActivatePlayer();
        if (GameManager.Instance.LevelSelected == Gdata.LevelCompleted)
        {
            Gdata.LevelCompleted++;
            //GameManager.Instance.LevelSelected = Gdata.LevelCompleted;
            PersistentDataManager.instance.SaveData();
        }
        //int e;
        //e = (GameManager.Instance.LevelSelected+1) * 1000;
        //ERW.text=string.Format("{0}", e);
        //Total = e;
        //Gdata.Coins += Total;
        //PersistentDataManager.instance.SaveData();
        //TotalW.text = string.Format("{0}", Total);
        //if (GameManager.Instance.LevelSelected == 4 || GameManager.Instance.levelRewarded && GameManager.Instance.GMode == 1)
        //{
        //    GameManager.Instance.levelRewarded = false;
        //    CompletePanal.transform.Find("Next").gameObject.SetActive(false);
        //}
        //else if (GameManager.Instance.LevelSelected == 9 || GameManager.Instance.levelRewarded && GameManager.Instance.GMode==2)
        //{
        //    GameManager.Instance.levelRewarded = false;
        //    CompletePanal.transform.Find("Next").gameObject.SetActive(false);
        //}
    }



    public void LevelFailedActivate()
    {
        GamePlayHandler.Instance.DeActivatePlayer();
        LevelFail.SetActive(true);
        //int e;
        //e = (GameManager.Instance.LevelSelected + 1) * 500;
        //ERL.text = string.Format("{0}", e);
        //Total = e;
        //Gdata.Coins += Total;
        //PersistentDataManager.instance.SaveData();
        //TotalL.text = string.Format("{0}", Total);
    }
    public void ActivateTimesUp()
    {

        TimesUP.SetActive(true);
        Time.timeScale = 0;
    }
    public void WatchVideoCoin2x()
    {
        GameManager.Instance.WatchVideoCoin = true;
    }
    public void Replay()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        GameManager.Instance.ChangeScene("GamePlay");
        //Gdata.LevelCompleted--;
        //GameManager.Instance.LevelSelected = Gdata.LevelCompleted;
        //PersistentDataManager.instance.SaveData();
    }
    public void Retry()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        GameManager.Instance.ChangeScene("GamePlay");
        //Gdata.LevelCompleted--;
        //GameManager.Instance.LevelSelected = Gdata.LevelCompleted;
        //PersistentDataManager.instance.SaveData();
    }
    public void Next()
    {
        Time.timeScale = 1;
        GameManager.Instance.LevelSelected++;
        GameManager.Instance.ChangeScene("GamePlay");
    }
    public void Home()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        GameManager.Instance.ChangeScene("MainManu");
    }
    public void LevelSelection()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        GameManager.Instance.ChangeScene("LevelSelection");
    }
    public void Continue()
    {
        GameManager.Instance.Continue = true;
    }

    public void CancelTimeUp()
    {
        Time.timeScale = 1;
        TimesUP.SetActive(false);
        LevelFailedActivate();
        
    }
    bool pause;
    public void Pause()
    {
        PausePanal.SetActive(true);
        AudioListener.pause = true;
        pause = true;
        Time.timeScale = 0;
    }
    public void Resume()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        pause = false;
        PausePanal.SetActive(false);   
    }

    public void DeActivateGamePlayButtons()
    {
        for(int i=0; i< GamePlayButtons.Length;i++)
        {
            GamePlayButtons[i].SetActive(false);
        }
    }
    public void ActivateGamePlayButtons()
    {
        for (int i = 0; i < GamePlayButtons.Length; i++)
        {
            GamePlayButtons[i].SetActive(true);
        }
    }
}
