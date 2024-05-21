using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    public Text HitText;
    public static int Hit;

    void Start()
    {
        Hit = 0;
    }

    // Update is called once per frame
    void Update()
    {
        HitText.text = "Coin:" + Hit;
    }
}
