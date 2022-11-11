using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int LevelSelected, GMode, Enovrment, Controll, Score;
    public GameData StoreData;
    public bool SoundStop;
    public bool flag;
    public bool GamePlayToMainManu;
    public bool Continue,Hint,levelRewarded,ObjectBuy, ContinueCheck,WatchF, WatchVideoCoin;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        Controll = 1;
    }
    public void ChangeScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
