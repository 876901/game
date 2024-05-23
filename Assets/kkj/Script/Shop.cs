using UnityEngine;

public class Shop : MonoBehaviour
{

    public GameObject ShopPanel; // 활성화/비활성화할 캔버스 GameObject를 연결할 변수
    public KeyCode toggleKey = KeyCode.P; // 캔버스를 토글할 키를 설정할 변수 (기본값은 P 키)

    private RaycastHit hit;

    void Start()
    {
        // 캔버스가 연결되어 있지 않은 경우 에러 출력
        if (ShopPanel == null)
        {
            Debug.LogError("캔버스를 찾을 수 없습니다!");
        }
        else
        {
            // 캔버스 비활성화
            ShopPanel.SetActive(false);
        }
    }

    void Update()
    {
        // 설정된 키를 누르면 캔버스를 토글
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

    // 캔버스를 토글하는 함수
    void ToggleCanvas()
    {
        // 캔버스가 활성화되어 있는지 확인하고 상태에 따라 반대로 변경
        if (ShopPanel.activeSelf)
        {
            ShopPanel.SetActive(false); // 캔버스 비활성화
            Time.timeScale = 1.0f;
        }
        else
        {
            ShopPanel.SetActive(true); // 캔버스 활성화
            Time.timeScale = 0;
        }
    }
    // 총알 강화
    public static bool bullActive;
    private bool active = false;
    private int bullValue = 1;

    public void UpgradeBull()
    {
        if (Score.Hit != 0 && Score.Hit >= bullValue)
        {
            Score.Hit = Score.Hit - 1;
            Debug.Log("총알 구매 성공");

            if (!active)
            {
                bullActive = !bullActive;
                active = true;
            }
        }
        else
        {
            Debug.Log("구매 불가");
        }
    }
    // 회복
    private int hpValue = 1;

    public void UpgradeHP()
    {
        if (Score.Hit != 0 && Score.Hit >= hpValue)
        {
            Score.Hit = Score.Hit - 1;
            Hp.HP = Hp.HP + 5;
            Debug.Log("체력 회복");
        }
        else
        {
            Debug.Log("구매 불가");
        }
    }

    private int reloadValue = 1;

    public void UpgradeReload()
    {
        if (Score.Hit != 0 && Score.Hit >= reloadValue)
        {
            Score.Hit = Score.Hit - 1;
            Debug.Log("총알 구매");
            GunsController.bulletsLeft += 100;
        }
        else
        {
            Debug.Log("구매 불가");
        }
    }
}