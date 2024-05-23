using UnityEngine;

public class Shop : MonoBehaviour
{

    public GameObject ShopPanel; // Ȱ��ȭ/��Ȱ��ȭ�� ĵ���� GameObject�� ������ ����
    public KeyCode toggleKey = KeyCode.P; // ĵ������ ����� Ű�� ������ ���� (�⺻���� P Ű)

    private RaycastHit hit;

    void Start()
    {
        // ĵ������ ����Ǿ� ���� ���� ��� ���� ���
        if (ShopPanel == null)
        {
            Debug.LogError("ĵ������ ã�� �� �����ϴ�!");
        }
        else
        {
            // ĵ���� ��Ȱ��ȭ
            ShopPanel.SetActive(false);
        }
    }

    void Update()
    {
        // ������ Ű�� ������ ĵ������ ���
        if (Input.GetKeyDown(toggleKey))
        {
            ToggleCanvas();
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        if (Input.GetMouseButtonDown(0))
        {

        }
        /*
        if (ShopPanel.activeSelf && Input.GetKeyDown(KeyCode.Alpha1))
        {
            UpgradeBull();
        }

        if (ShopPanel.activeSelf && Input.GetKeyDown(KeyCode.Alpha2))
        {
            UpgradeHP();
        }

        if (ShopPanel.activeSelf && Input.GetKeyDown(KeyCode.Alpha3))
        {
            UpgradeReload();
        }*/
    }

    // ĵ������ ����ϴ� �Լ�
    void ToggleCanvas()
    {
        // ĵ������ Ȱ��ȭ�Ǿ� �ִ��� Ȯ���ϰ� ���¿� ���� �ݴ�� ����
        if (ShopPanel.activeSelf)
        {
            ShopPanel.SetActive(false); // ĵ���� ��Ȱ��ȭ
            Time.timeScale = 1.0f;
        }
        else
        {
            ShopPanel.SetActive(true); // ĵ���� Ȱ��ȭ
            Time.timeScale = 0;
        }
    }
    // �Ѿ� ��ȭ
    public static bool bullActive;
    private bool active = false;
    private int bullValue = 1;

    public void UpgradeBull()
    {
        if (Score.Hit != 0 && Score.Hit >= bullValue)
        {
            Score.Hit = Score.Hit - 1;
            Debug.Log("�Ѿ� ���� ����");

            if (!active)
            {
                bullActive = !bullActive;
                active = true;
            }
        }
        else
        {
            Debug.Log("���� �Ұ�");
        }
    }
    // ȸ��
    private int hpValue = 1;

    public void UpgradeHP()
    {
        if (Score.Hit != 0 && Score.Hit >= hpValue)
        {
            Score.Hit = Score.Hit - 1;
            Hp.HP = Hp.HP + 5;
            Debug.Log("ü�� ȸ��");
        }
        else
        {
            Debug.Log("���� �Ұ�");
        }
    }

    private int reloadValue = 1;

    public void UpgradeReload()
    {
        if (Score.Hit != 0 && Score.Hit >= reloadValue)
        {
            Score.Hit = Score.Hit - 1;
            Debug.Log("�Ѿ� ����");
            GunsController.bulletsLeft += 100;
        }
        else
        {
            Debug.Log("���� �Ұ�");
        }
    }
}