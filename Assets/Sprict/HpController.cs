using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpController : MonoBehaviour
{
    //Playerの体力
    float _maxHp = 5f;

    //テキスト
    [SerializeField] Text _hpText;

    Slider _hpslider;
    PlayerController _player;

    float _hp = 0;

    void Start()
    {
        _hpslider = GetComponent<Slider>();
        _player = GameObject.FindObjectOfType<PlayerController>();
        _hpslider.maxValue = _maxHp;
    }

    void Update()

    {
        _hp = _player._life;
        _hpText.text = _hp.ToString();
        

    }
    /// <summary>Hpをスライダーに表示させるメソッド</summary>
    public void UpdateSlider(int hp)
    {
        _hpslider.value = hp;
    }
}
