using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hp : MonoBehaviour
{
    public Slider slider;
    public static int maxHP;
    public static int HP;

    void Start()
    {
        HP = 15;
        maxHP = 15;
    }

    // Update is called once per frame
    void Update()
    {
        slider.maxValue = maxHP; // 슬라이더의 최대 값 설정
        slider.value = HP; // 초기에 현재 값을 최대 값으로 설정
    }
}
