using UnityEngine;
using UnityEngine.UI;

public class Hpbar : MonoBehaviour
{
    public Slider slider; // �����̴� UI ��ҿ� ���� ����
    public static float maxHP;

    public void SetMaxHP(int maxHP)
    {
        slider.maxValue = maxHP; // �����̴��� �ִ� �� ����
        slider.value = maxHP; // �ʱ⿡ ���� ���� �ִ� ������ ����
    }

    public void SetHP(int hp)
    {
        slider.value = hp; // ���� HP�� �ݿ��ϱ� ���� �����̴� �� ������Ʈ
    }
}
