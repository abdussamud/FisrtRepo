using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadingHandler : MonoBehaviour
{
    public GameData Gdata;
    public RectTransform LoadingLine;
    void Start()
    {
        StartCoroutine(Loading());
    }

    IEnumerator Loading()
    {
        if (GameManager.Instance.flag)
        {
            LoadingLine.GetComponent<Image>().DOFillAmount(1, 5);
            GameManager.Instance.flag = false;
            AsyncOperation operation = SceneManager.LoadSceneAsync("GamePlay");
            operation.allowSceneActivation = false;
            yield return new WaitForSecondsRealtime(5f);
            operation.allowSceneActivation = true;

        }
        else
        {
            LoadingLine.GetComponent<Image>().DOFillAmount(1, 5);
            GameManager.Instance.flag = true;
            AsyncOperation operation = SceneManager.LoadSceneAsync("LevelSelection");
            operation.allowSceneActivation = false;
            yield return new WaitForSecondsRealtime(5f);
            operation.allowSceneActivation = true;

        }
    }
}
