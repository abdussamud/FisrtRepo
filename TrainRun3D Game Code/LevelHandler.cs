using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    public static LevelHandler Instance;
    public GameObject[] leveUnlockMode1;
    public GameObject[] leveUnlockMode2;
    public GameObject[] LevelActive;
    public GameObject[] LevelClear;
    public GameObject Mode1;
    public GameObject Mode2;
    public GameData Gdata;
    public int LevelSelectionLevel;
    public int RewardLevel;
    // Start is called before the first frame update
    void Start()
    {
        //if (GameManager.Instance.GMode == 0)
        //{
        //    Mode1.SetActive(true);
        //    LeveUlockingMode1();  
        //}
        //else if (GameManager.Instance.GMode == 1)
        //{
        //    Mode2.SetActive(true);
        //    LeveUlockingMode2();
        //}

    }
    private void Update()
    {
        if (Gdata.LevelCompleted == 2)
        {
            for (int i = 0; i < 1; i++)
            {
                LevelActive[i].SetActive(true);
                LevelClear[i].SetActive(true);
            }
        }
        if (Gdata.LevelCompleted == 3)
        {
            for (int i = 0; i < 2; i++)
            {
                LevelActive[i].SetActive(true);
                LevelClear[i].SetActive(true);
            }
        }
        if (Gdata.LevelCompleted == 4)
        {
            for (int i = 0; i < 3; i++)
            {
                LevelActive[i].SetActive(true);
                LevelClear[i].SetActive(true);
            }
        }
        if (Gdata.LevelCompleted == 5)
        {
            for (int i = 0; i < 4; i++)
            {
                LevelActive[i].SetActive(true);
                LevelClear[i].SetActive(true);
            }
        }
        if (Gdata.LevelCompleted == 6)
        {
            for (int i = 0; i < 5; i++)
            {
                LevelActive[i].SetActive(true);
                LevelClear[i].SetActive(true);
            }
        }
        if (Gdata.LevelCompleted == 7)
        {
            for (int i = 0; i < 6; i++)
            {
                LevelActive[i].SetActive(true);
                LevelClear[i].SetActive(true);
            }
        }
        if (Gdata.LevelCompleted == 8)
        {
            for (int i = 0; i < 7; i++)
            {
                LevelActive[i].SetActive(true);
                LevelClear[i].SetActive(true);
            }
        }
        if (Gdata.LevelCompleted == 9)
        {
            for (int i = 0; i < 8; i++)
            {
                LevelActive[i].SetActive(true);
                LevelClear[i].SetActive(true);
            }
        }
        if (Gdata.LevelCompleted == 10)
        {
            for (int i = 0; i < 9; i++)
            {
                //LevelActive[i].SetActive(true);
                LevelClear[i].SetActive(true);
            }
        }
    }

    void LeveUlockingMode1()
    {
        for (int i = 1; i <= Gdata.levelCompletedMode1; i++)
        {
            leveUnlockMode1[i].SetActive(false);
        }
    }
    void LeveUlockingMode2()
    {
        for (int i = 1; i <= Gdata.levelCompletedMode2; i++)
        {
            leveUnlockMode2[i].SetActive(false);
        }
    }
    public void PressedBackButton()
    {
        if (GameManager.Instance.GMode == 0)
        {
            GameManager.Instance.flag = false;
            GameManager.Instance.ChangeScene("MainManu");
        }
        else if (GameManager.Instance.GMode == 1)
        {
            GameManager.Instance.flag = false;
            GameManager.Instance.ChangeScene("MainManu");
        }
    }
    public void ChangeSceneAndLevel(int Level)
    {
        GameManager.Instance.LevelSelected = Level;
        StartLoadingHandler.SceneSwitchCheker = 2;
        SceneManager.LoadScene("Loading1");
        //if (GameManager.Instance.GMode == 0)
        //{
        //    GameManager.Instance.ChangeScene("Loading");

        //}
        //else if (GameManager.Instance.GMode == 1)
        //{
        //    GameManager.Instance.ChangeScene("Loading");
        //}

    }
    public void WatchVideo(int level)
    {
        GameManager.Instance.LevelSelected = level;
        GameManager.Instance.levelRewarded = true;
    }
    public void Next()
    {
        
        if (GameManager.Instance.GMode == 0)
        {
            GameManager.Instance.LevelSelected = Gdata.levelCompletedMode1;
            GameManager.Instance.ChangeScene("Loading");
        }
        else if (GameManager.Instance.GMode == 1)
        {
            GameManager.Instance.LevelSelected = Gdata.levelCompletedMode2;
            GameManager.Instance.ChangeScene("Loading");
        }

    }
}
