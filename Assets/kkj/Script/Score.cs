using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    public Text HitText;
    public static int Hit;
    public Text end;
    private float endGame;

    void Start()
    {
        Hit = 0;
        endGame = 150f;

    }

    // Update is called once per frame
    void Update()
    {
        endGame -= Time.deltaTime;
        end.text = "게임 종료: " + Mathf.Round(endGame);

        HitText.text = "Coin:" + Hit;
    }
}
