using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemyhp : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;
    public int EmaxHP;
    public int EHP;
    

    void Start()
    {
        EHP = 10;
        EmaxHP = 10;
    }
    public void TankDamage(int damage)
        {
            EHP -= damage;
        
        if (EHP <= 0)
        {
            Destroy(gameObject);
            Score.Hit++;

        }


    }
    // Update is called once per frame
    void Update()
    {
        slider.maxValue = EmaxHP; // 슬라이더의 최대 값 설정
        
        slider.value = EHP;
    }
    

}
