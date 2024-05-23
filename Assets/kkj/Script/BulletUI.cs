using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletUI : MonoBehaviour
{
    public Text bulletsText;

    void Start()
    {
        // 초기화 작업이 필요하면 여기서 처리
    }

    void Update()
    {
        bulletsText.text = "Bullet: " + GunsController.currentBullets.ToString();
    }
}
