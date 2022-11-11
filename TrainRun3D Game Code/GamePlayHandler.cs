using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class GamePlayHandler : MonoBehaviour
{
    public static GamePlayHandler Instance;
    public GameObject[] Player;
    public GameObject Timehandler, ArrowGuider;
    public LevelMode1[] levelmode1;
    public LevelMode2[] levelmode2;
    public LevelMode3[] levelmode3;
    public int LevelNum;
    public GameObject WonCutCam;
    public GameObject StartCutCam;
    public GameObject CameraTimeline,GameCamera;
    public GameData Gdata;

    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        GameManager.Instance.GamePlayToMainManu = true;
        LevelNum = GameManager.Instance.LevelSelected;
        ActivatFunctionsCalling();
        if (Gdata.LevelCompleted == 1)
        {
            ArrowGuider.SetActive(true);
            Invoke(nameof(ArrowGuiderImgDeactive), 1);
            Invoke(nameof(ArrowGuiderImgActive), 2);
            Invoke(nameof(ArrowGuiderImgDeactive), 3);
            Invoke(nameof(ArrowGuiderImgActive), 4);
            Invoke(nameof(ArrowGuiderImgDeactive), 5);
        }
        //StartCoroutine(Loading());
    }

    private void ArrowGuiderImgDeactive()
    {
        ArrowGuider.SetActive(false);
    }
    
    private void ArrowGuiderImgActive()
    {
        ArrowGuider.SetActive(true);
    }


    IEnumerator Loading()
    {
        GameCamera.SetActive(false);
        UIManager.Instance.DeActivateGamePlayButtons();
        ActivatFunctionsCalling();
        CameraTimeline.SetActive(true);
        StartCutCam.SetActive(true);
        float camLength = (float)StartCutCam.GetComponent<PlayableDirector>().duration;
        yield return new WaitForSeconds(camLength);
        GameCamera.SetActive(true);
        CameraTimeline.SetActive(false);
        StartCutCam.SetActive(false);
        UIManager.Instance.ActivateGamePlayButtons();
    }
    public void ActivateCutCam()
    {

        WonCutCam.SetActive(true);

    }
    public void DeActivateCutCam()
    {
        WonCutCam.SetActive(false);
    }
    public void ActivatFunctionsCalling()
    {

        //ActivateTime();
        ActivateEnvoirment();
        ActivatePlayer();
    }
    public void DeActivatFunctionsCalling()
    {
        DeActivatePlayer();
        DeActivateTime();
        DeActivateEnvoirment();
    }



    public void ActivatePlayer()
    {
        //if (GameManager.Instance.GMode == 0)
        //{
        //    Player[Gdata.PlayerSelected].transform.SetPositionAndRotation(levelmode1[LevelNum].PlayerPos.transform.position, levelmode1[LevelNum].PlayerPos.transform.rotation);
        //    Player[Gdata.PlayerSelected].SetActive(true);
        //}
        //else if(GameManager.Instance.GMode==1)
        //{
        //    Player[Gdata.PlayerSelected].transform.SetPositionAndRotation(levelmode2[LevelNum].PlayerPos.transform.position, levelmode2[LevelNum].PlayerPos.transform.rotation);
        //    Player[Gdata.PlayerSelected].SetActive(true);
        //}
        //else if (GameManager.Instance.GMode == 2)
        //{
        //    Player[Gdata.PlayerSelected].transform.SetPositionAndRotation(levelmode3[LevelNum].PlayerPos.transform.position, levelmode3[LevelNum].PlayerPos.transform.rotation);
        //    Player[Gdata.PlayerSelected].SetActive(true);
        //}
    }

    public void DeActivatePlayer()
    {
        Player[Gdata.PlayerSelected].SetActive(false);
    }

    //private void ActivateTime()
    //{
    //    if (GameManager.Instance.GMode == 0)
    //    {
    //        Timehandler.SetActive(true);
    //        TimeHandler.Instance.timeLeft = levelmode1[LevelNum].time;
    //    }
    //    else if (GameManager.Instance.GMode == 1)
    //    {
    //        Timehandler.SetActive(true);
    //        TimeHandler.Instance.timeLeft = levelmode2[LevelNum].time;
    //    }
    //    else if (GameManager.Instance.GMode == 2)
    //    {
    //        Timehandler.SetActive(true);
    //        TimeHandler.Instance.timeLeft = levelmode3[LevelNum].time;
    //    }
    //}
    private void DeActivateTime()
    {
        Timehandler.SetActive(false);
    }

    public void ActivateEnvoirment()
    {
        //if (GameManager.Instance.GMode == 0)
        //{
        //    for (int i = 0; i < levelmode1[LevelNum].Envoirment.Length; i++)
        //    {
        //        levelmode1[LevelNum].Envoirment[i].SetActive(true);
        //    }
        //}
        //else if (GameManager.Instance.GMode == 1)
        //{
        //    for (int i = 0; i < levelmode2[LevelNum].Envoirment.Length; i++)
        //    {
        //        levelmode2[LevelNum].Envoirment[i].SetActive(true);
        //    }
        //}
        //else if (GameManager.Instance.GMode == 2)
        //{
        //    for (int i = 0; i < levelmode3[LevelNum].Envoirment.Length; i++)
        //    {
        //        levelmode3[LevelNum].Envoirment[i].SetActive(true);
        //    }
        //}
    }

    public void DeActivateEnvoirment()
    {
        if (GameManager.Instance.GMode == 0)
        {
            for (int i = 0; i < levelmode1[LevelNum].Envoirment.Length; i++)
            {
                levelmode1[LevelNum].Envoirment[i].SetActive(false);
            }
        }
        else if (GameManager.Instance.GMode == 1)
        {
            for (int i = 0; i < levelmode2[LevelNum].Envoirment.Length; i++)
            {
                levelmode2[LevelNum].Envoirment[i].SetActive(false);
            }
        }
        else if (GameManager.Instance.GMode == 2)
        {
            for (int i = 0; i < levelmode3[LevelNum].Envoirment.Length; i++)
            {
                levelmode3[LevelNum].Envoirment[i].SetActive(false);
            }
        }
    }
}
[Serializable]

public class LevelMode1
{
    [Header("Player Position")]
    public Transform PlayerPos;
    [Header("GameTime")]
    public float time;
    [Header("Envoirment")]
    public GameObject[] Envoirment;
}
[Serializable]

public class LevelMode2
{
    [Header("Player Position")]
    public Transform PlayerPos;
    [Header("GameTime")]
    public float time;
    [Header("Envoirment")]
    public GameObject[] Envoirment;
}
[Serializable]

public class LevelMode3
{
    [Header("Player Position")]
    public Transform PlayerPos;
    [Header("GameTime")]
    public float time;
    [Header("Envoirment")]
    public GameObject[] Envoirment;
}