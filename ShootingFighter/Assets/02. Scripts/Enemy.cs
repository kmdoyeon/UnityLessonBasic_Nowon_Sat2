using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public GameObject destroyEffect;
    public LayerMask targetLayer;
    public int damage;
    public int score;
    

    private int _hp;  // _ 는 멤버 변수라는 뜻으로 사용 
    public int hp
    {
        set
        {
            if (value > 0 )
             _hp = value;
            else
            {
                _hp = 0;
                Player.instance.score += score;
                DoDestoryEffect();
                Destroy(gameObject);
            }
            
            hpSlider.value = (float)_hp / hpMax;

        }

        get
        {
            return _hp;
        }
    }
    public int hpMax; 
    public Slider hpSlider;


     

    public void DoDestoryEffect()
    {
        GameObject go = Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(go, 3); 
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            
            Player.instance.hp -= damage;
            Destroy(gameObject);
        }
    }

}
