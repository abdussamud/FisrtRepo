using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StartLoadingHandler : MonoBehaviour
{
    public GameData Gdata;
    public Transform LodingBarImage;
    public RectTransform LoadingLine;
    public Text LodingValue;
    public static int SceneSwitchCheker = 1;

    private void Start()
    {
        if (SceneSwitchCheker == 1)
        {
            _ = StartCoroutine(Loading1);
        }
        else
        {
            _ = StartCoroutine(Loading2);
        }
        _ = LoadingLine.GetComponent<Image>().DOFillAmount(1, 12);
        _ = LodingBarImage.DOLocalMoveX(350, 6.5f, true).SetEase(Ease.Linear);
        _ = DOTween.To(() => 5, x => LodingValue.text = $"{x}%", 100, 9f).SetEase(Ease.Linear);
    }

    private IEnumerator Loading1
    {
        get
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync("MainManu");
            operation.allowSceneActivation = false;
            yield return new WaitForSecondsRealtime(7f);
            operation.allowSceneActivation = true;
            SceneSwitchCheker = 2;
        }
    }

    private IEnumerator Loading2
    {
        get
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync("GamePlay");
            operation.allowSceneActivation = false;
            yield return new WaitForSecondsRealtime(7f);
            operation.allowSceneActivation = true;
            //SceneSwitchCheker = 1;
        }
    }
}
