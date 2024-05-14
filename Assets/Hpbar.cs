using UnityEngine;
using UnityEngine.UI;

public class Hpbar : MonoBehaviour
{
    public Slider slider; // 슬라이더 UI 요소에 대한 참조
    public static float maxHP;

    public void SetMaxHP(int maxHP)
    {
        slider.maxValue = maxHP; // 슬라이더의 최대 값 설정
        slider.value = maxHP; // 초기에 현재 값을 최대 값으로 설정
    }

    public void SetHP(int hp)
    {
        slider.value = hp; // 현재 HP를 반영하기 위해 슬라이더 값 업데이트
    }
}
