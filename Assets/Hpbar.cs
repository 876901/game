using UnityEngine;
using UnityEngine.UI;

public class Hpbar : MonoBehaviour
{
    public Slider slider; // �����̴� UI ��ҿ� ���� ����
    public static float maxHP;
    public static float HP;

    void Start()
    {
        HP = 10;
        maxHP = 10;
    }


    public void SetMaxHP(float maxHP)
    {
        slider.maxValue = maxHP; // �����̴��� �ִ� �� ����
        slider.value = HP; // �ʱ⿡ ���� ���� �ִ� ������ ����
    }

    public void SetHP(float hp)
    {
        slider.value = hp; // ���� HP�� �ݿ��ϱ� ���� �����̴� �� ������Ʈ
    }
}
