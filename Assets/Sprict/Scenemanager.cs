using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Scenemanager : MonoBehaviour
{
    [Header("ExitPannelの貼り付け")]
    [SerializeField] GameObject _exitPannel;
    [Header("FadePannelの貼り付け")]
    [Space(10)]
    [SerializeField] Image _fadePannel;

    private void Start()
    {
        StartFadeIn();
    }

    private void Update()
    {
        if (Input.GetButton("Cancel"))
        {
            _exitPannel.SetActive(true);
        }
    }


    public void StartFadeOut(string scene)//フェードアウト関数
    {
        _fadePannel.gameObject.SetActive(true);
        _fadePannel.DOFade(endValue: 1f, duration: 1f).OnComplete(() => SceneManager.LoadScene(scene));
        //PannelのColorは透明に設定
    }

    public void StartFadeIn()//フェードイン関数
    {
        _fadePannel.DOFade(endValue: 0f, duration: 1f).OnComplete(() => _fadePannel.gameObject.SetActive(false));
        //PannelのColorは黑に設定
    }

    public void Fade(bool type, string scene)//呼び出す関数
    {
        if (type)
        {
            _fadePannel.DOFade(endValue: 0f, duration: 1f).OnComplete(() => _fadePannel.gameObject.SetActive(false));
            //PannelのColorは黑に設定
        }
        else
        {
            _fadePannel.gameObject.SetActive(true);
            _fadePannel.DOFade(endValue: 1f, duration: 1f).OnComplete(() => SceneManager.LoadScene(scene));
            //PannelのColorは透明に設定
        }
    }


    public void Exit()
    {
        Application.Quit();
    }
}
