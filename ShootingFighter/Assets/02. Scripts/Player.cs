using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player instance;


    private int _hp;  // _ 는 멤버 변수라는 뜻으로 사용 
    public int hp
    { 
        set
        {
            if (value > 0)
                _hp = value;
            else
            {
                _hp = 0;
                Destroy(gameObject);
            }

            hpSlider.value = (float)_hp / hpMax;
            hpText.text = _hp.ToString();

        }

        get
        {
            return _hp;
        }
    }
    public int hpMax;
    public Slider hpSlider;
    public Text hpText;

    private int _score;

    public int score
    {
        set
        {
            _score = value;
            scoreText.text = _score.ToString();
        }
        get
        {
            return _score;
        }
    }

    public Text scoreText;

    private void Awake()
    {
        hp = hpMax;
        score = 0;
        instance = this;
    }
}
