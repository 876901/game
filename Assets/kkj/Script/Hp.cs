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
        slider.maxValue = maxHP; // �����̴��� �ִ� �� ����
        slider.value = HP; // �ʱ⿡ ���� ���� �ִ� ������ ����
    }
}
