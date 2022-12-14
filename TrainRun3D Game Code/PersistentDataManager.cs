using Newtonsoft.Json;
using UnityEngine;

public class PersistentDataManager : MonoBehaviour
{
    public GameData gameData;

    #region Singleton
    public static PersistentDataManager instance;
    internal readonly object gameDataFromPlayerPrefs;

    void Awake() 
    {
        GetInstance();
    }

    void GetInstance()
    {
        if(instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    #endregion
    
    void Start()
    {
        LoadData();
        // PlayerPrefs.DeleteAll();
    }

    void OnApplicationQuit()
    {
        SaveData();
    }

    public void SaveData()
    {
        string gameDataString = JsonConvert.SerializeObject(gameData);
        PlayerPrefs.SetString("GameData", gameDataString);
        PlayerPrefs.Save();
        print("GameData Saved In PlayerPrefs: " + PlayerPrefs.GetString("GameData"));
    }

    public void LoadData()
    {
        string gameDataString = PlayerPrefs.GetString("GameData");
        GameData gameDataFromPlayerPrefs = JsonConvert.DeserializeObject<GameData>(gameDataString);
        if (gameDataFromPlayerPrefs == null)
        {
            print("Game is played first time. No GameData found.");
            return;
        }
        print("GameData Loaded From PlayerPrefs");

        // Set Local GameData Variables Here - Start
        gameData.LevelCompleted = gameDataFromPlayerPrefs.LevelCompleted;
        gameData.levelCompletedMode1 = gameDataFromPlayerPrefs.levelCompletedMode1;
        gameData.levelCompletedMode2 = gameDataFromPlayerPrefs.levelCompletedMode2;
        gameData.PlayerSelected = gameDataFromPlayerPrefs.PlayerSelected;
        gameData.PlayerBuy = gameDataFromPlayerPrefs.PlayerBuy;
        gameData.Coins = gameDataFromPlayerPrefs.Coins;
        // Set Local GameData Variables Here - End
    }
}
