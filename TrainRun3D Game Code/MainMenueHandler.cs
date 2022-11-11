using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System.Collections.Generic;

public class MainMenueHandler : MonoBehaviour
{
    public static MainMenueHandler Instance;
    public GameObject[] LevelActive;
    public GameObject[] LevelClear;
    public GameData Gdata;
    public GameObject EverythingPanal, LessMoney, SettingPanal, ShopPanal, PlayerSelection, MainPanal, EnvoirmentPanal, LevelSelectionPanel,
        ExitPanal, next, priv, Add, ModePanal, stearingOn, ButtonOn, TrainSelectionPanel, RateUsPanel, UnlocEveryThingPanel;
    public GameObject[] TrainUnlock;
    public GameObject[] Train, TrainMesh;
    public int checkTrain;
    public ParticleSystem ChangeTrain;
    public Text Coin;
    public Text Music;
    public Text Volume;
    public int[] TrainPrice;
    public AudioMixer Mixer;
    public GameObject volumeslider;
    public GameObject musicslider;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        ActiveEverythingPanal();
        int Check = 0;
        for (int i = 0; i < Gdata.PlayerBuy.Length; i++) { if (Gdata.PlayerBuy[i]) { Check++; } }
        Coin.text = string.Format("{0}", Gdata.Coins);
        checkTrain = 0;
        TrainUlocking();
        if (GameManager.Instance.GamePlayToMainManu) { GameManager.Instance.GamePlayToMainManu = false; }
        if (Gdata.RemoveAds) { Add.SetActive(true); }
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

    public void RemoveAdsButton()
    {
        Debug.Log("RemoveAdsButton Is Pressed");
    }
    
    public void TrainSelectionButton()
    {
        TrainSelectionPanel.SetActive(true);
        Debug.Log("TrainSeletionButton Is Pressed");
    }

    public void TrainSelectionButtonExit()
    {
        TrainSelectionPanel.SetActive(false);
        Debug.Log("TrainSelectionButtonExit Is Pressed");
    }
    public void Next()
    {
        ChangeTrain.Play();
        priv.SetActive(true);
        Train[checkTrain].SetActive(false);
        Train[checkTrain+1].SetActive(true);
        TrainMesh[checkTrain].SetActive(false);
        TrainMesh[checkTrain + 1].SetActive(true);
        checkTrain++;
        if (checkTrain == Train.Length-1)
        {
            next.SetActive(false);
        }
    }
    public void Privious()
    {
        ChangeTrain.Play();
        next.SetActive(true);
        Train[checkTrain].SetActive(false);
        Train[checkTrain-1].SetActive(true);
        TrainMesh[checkTrain].SetActive(false);
        TrainMesh[checkTrain - 1].SetActive(true);
        checkTrain--;
        if (checkTrain == 0)
        {
            priv.SetActive(false);
        }
        
        
    }
    public void TrainBuy(int Buy)
    {
        if(Buy>=1)
        {
            if(Gdata.Coins >= TrainPrice[Buy])
            {
                Gdata.Coins -= TrainPrice[Buy];
                Gdata.PlayerBuy[Buy] = true;
                TrainUlocking();
            }
            else
            {
                LessMoney.SetActive(true);
                Invoke(nameof(Des), 2);
            }
        }
    }
    public void Des()
    {
        LessMoney.SetActive(false);
        Shop();
    }
    public void TrainUlocking()
    {
        for(int i=1;i<TrainUnlock.Length;i++)
        {
            if (Gdata.PlayerBuy[i])
            {
                TrainUnlock[i].SetActive(false);
            }
        }
        Coin.text = string.Format("{0}", Gdata.Coins);
    }
    public void Playerselect(int player)
    {
        Gdata.PlayerSelected = player;
        PlayerSelection.SetActive(false);
        ModePanal.SetActive(true);
    }

    public void ChapterSelectoin() => ModePanal.SetActive(true);
    public void ChapterSelectoinBack() => ModePanal.SetActive(false);

    public void GameModeSelect(int mode)
    {
        GameManager.Instance.GMode = mode;
        ModePanal.SetActive(false);
        EnvoirmentPanal.SetActive(true);
    }
    public void EnvoirmentSelect(int envoirment)
    {
        GameManager.Instance.Enovrment = envoirment;
        GameManager.Instance.ChangeScene("Loading");
    }
    public void LevelSelection()
    {
        GameManager.Instance.ChangeScene("LevelSelection");
    }
    public void BackEnvoirmentSelect()
    {
        EnvoirmentPanal.SetActive(false);
        ModePanal.SetActive(true);
    }
    public void BackGameModeSelect()
    {
        ModePanal.SetActive(false);
        PlayerSelection.SetActive(true);
    }
    public void BackPlayerSelection()
    {
        PlayerSelection.SetActive(false);
        MainPanal.SetActive(true);
    }
    public void PrivacyPolicy() => Application.OpenURL("");
    public void MoreGames() => Application.OpenURL("");
    public void RateUs() => RateUsPanel.SetActive(true);
    public void RateUsNow() => Application.OpenURL("");

    public void RateUsLater() => RateUsPanel.SetActive(false);
    public void Setting() => SettingPanal.SetActive(true);
    public void SettingCancel()  => SettingPanal.SetActive(false);
    public void Shop() => ShopPanal.SetActive(true);
    public void ShopCancel() => ShopPanal.SetActive(false);
    public void UnlocEveryThingPanelButton() => UnlocEveryThingPanel.SetActive(true);
    public void UnlocEveryThingPanelExit() => UnlocEveryThingPanel.SetActive(false);
    public void UnlocEveryThingButton() => Application.OpenURL("");
    public void Exit() => ExitPanal.SetActive(true);
    public void ExitYes() => Application.Quit();
    public void ExitCancel() => ExitPanal.SetActive(false);
    public void ActiveEverythingPanal() => EverythingPanal.SetActive(true);
    public void BackEverythingPanal()
    {
        EverythingPanal.SetActive(false);
    }
    public void SetVolumeLevel(float sliderValue)
    {
        _ = Mixer.SetFloat("UI", Mathf.Log10(sliderValue) * 20);
    }
    public void Volumeamount()
    {
        Volume.text = ((int)(volumeslider.GetComponent<Slider>().value * 100)).ToString() + "%";
    }

    public void SetMusicLevel(float sliderValue)
    {
        _ = Mixer.SetFloat("BGM", Mathf.Log10(sliderValue) * 20);
    }
    public void MusicAmount()
    {
        Music.text = ((int)(musicslider.GetComponent<Slider>().value * 100)).ToString() + "%";
    }
    public void SoundOn()
    {
        Mixer.SetFloat("SFX", -3);
        Mixer.SetFloat("UI", -3);
    }
    public void SoundOf()
    {
        Mixer.SetFloat("SFX", -80);
        Mixer.SetFloat("UI", -80);
    }
    public void MusicOn()
    {
        Mixer.SetFloat("BGM", -3);
    }
    public void MusicOf()
    {
        Mixer.SetFloat("BGM", -80);
    }
    public void Controller(int controll)
    {
        if(controll==0)
        {
            stearingOn.SetActive(true);
            ButtonOn.SetActive(false);
        }
        else if(controll==1)
        {
            stearingOn.SetActive(false);
            ButtonOn.SetActive(true);
        }
        GameManager.Instance.Controll = controll;
    }
}
