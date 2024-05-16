using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemyhp : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;
    public static int EmaxHP;
    public static int EHP;
    

    void Start()
    {
        EHP = 5;
        EmaxHP = 5;
    }

    // Update is called once per frame
    void Update()
    {
        slider.maxValue = EmaxHP; // 슬라이더의 최대 값 설정
        slider.value = EHP; // 초기에 현재 값을 최대 값으로 설정
    }
}
