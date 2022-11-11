using UnityEngine;
[CreateAssetMenu(fileName = "GameData", menuName = "Settings/GameData", order = 1)]

public class GameData : ScriptableObject
{
    public int levelCompletedMode1, levelCompletedMode2, PlayerSelected, LevelCompleted = 1;
    public bool[] PlayerBuy ;
    public int Coins;
    public int TotalScores;
    public string PlayerName;
    public bool SetPlayerName;
    public bool RemoveAds;
    public bool FirstTime;

    [Header("Data From Server")]

    /*-------------Data From Server-------------*/

    [Header("Priority Instertial For MainMenu To Level")]
    public string FirstPriorityMainMenuToLevel;
    public string SecondPriorityMainMenuToLevel;

    [Header("Priority Instertial For Level To Loading")]
    public string FirstPriorityLevelToLoading;
    public string SecondPriorityLevelToLoading;

    [Header("Priority Instertial For Pause")]
    public string FirstPriorityPause;
    public string SecondPriorityPause;

    [Header("Priority Instertial For Level Complete")]
    public string FirstPriorityLevelComplete;
    public string SecondPriorityLevelComplete;

    [Header("Priority Instertial For Level Fail")]
    public string FirstPriorityLevelFail;
    public string SecondPriorityLevelFail;

    [Header("Priority Instertial For GamePlay To MainMenu")]
    public string FirstPriorityGamePlayToMainMenu;
    public string SecondPriorityGamePlayToMainMenu;

    [Header("Priority Banner")]
    public string FirstPriorityBanner;
    public string SecondPriorityBanner;

    [Header("Priority Rewarded")]
    public string FirstPriorityRewarded;
    public string SecondPriorityRewarded;

    [Header("Instertial Ads")]
    public bool PlayButtonInstertial;
    public bool LevelButtonInstertitial;
    public bool LevelCompleteInstertial;
    public bool LevelFailInstertial;
    public bool PauseButtonInstertial;
    public bool MenuButtonInstertial;

    [Header("Banner")]
    public bool GamePlayBanner;
    public bool OtherBanner;

    [Header("Rewarded Video")]
    public bool RewardedVideoServer;

    [Header("NativeAds")]
    public bool FirstLoadingScreenNativeAd;
    public bool MainMenuScreenNativeAd;
    public bool CharacterSelectionScreenNativeAd;
    public bool SecondLoadingScreenNativeAd;
    public bool PausePanelNativeAd;
    public bool LevelCompletePanelNativeAd;
    public bool LevelFailPanelNativeAd;
    public bool ExitPanelNativeAd;
}
