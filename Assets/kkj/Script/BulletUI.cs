using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletUI : MonoBehaviour
{
    public Text bulletsText;

    void Start()
    {
        // �ʱ�ȭ �۾��� �ʿ��ϸ� ���⼭ ó��
    }

    void Update()
    {
        bulletsText.text = "Bullet: " + GunsController.currentBullets.ToString();
    }
}
