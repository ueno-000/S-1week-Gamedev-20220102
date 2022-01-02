using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class SceneManager : MonoBehaviour
{
    [Header("FadePannelの貼り付け")]
    [SerializeField] GameObject _fadePannel;
    [SerializeField] GameObject _exitPannel;

    private void Update()
    {
        if(Input.GetButton("Cancel"))
        {
            _exitPannel.SetActive(true);
        }
    } 


    public void StartFadeOut(string scene)//フェードアウト関数
    {
        _fadePannel.SetActive(true);
        _fadePannel.DOFade(endValue: 1f, duration : 1f).OnComplate(() => SceneManager.LoadScene(scene));
        //PannelのColorは透明に設定
    }

    public void StartFadeIn()//フェードイン関数
    {
        _fadePannel.DOFade(endValue: 0f, duration: 1f).OnComplate(() => _fadePannel.SetActive(false));
        //PannelのColorは黑に設定
    }

    public void Fade(bool type, string scene)//呼び出す関数
    {
        if(type)
        {
            _fadePannel.DOFade(endValue: 0f, duration: 1f).OnComplate(() => _fadePannel.SetActive(false));
            //PannelのColorは黑に設定
        }
        else 
        {
            _fadePannel.SetActive(true);
            _fadePannel.DOFade(endValue: 1f, duration: 1f).OnComplate(() => SceneManager.LoadScene(scene));
            //PannelのColorは透明に設定
        }
    }


    public void Exit()
    {
        Application.Quit();
    }
}
