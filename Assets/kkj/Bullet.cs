using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Bullet : MonoBehaviour
{
    public int power = 1700;
    private float dTime = 2.0f;
    public AudioClip sound; //재생 사운드 저장
    public GameObject exp;


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * power);
        //GetComponent<Rigidbody>().AddForce(transform.forward * power);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider col)
    {

        AudioSource.PlayClipAtPoint(sound, this.transform.position);// transform.position 위치에서 재생
        GameObject copy_exp = Instantiate(exp) as GameObject;
        copy_exp.transform.position = this.transform.position;
        Destroy(gameObject);
        //col 이 Wall 태그에 부딛치면 
        //벽과 총알을 없앤다 

        if (col.gameObject.tag == "Wall")
        {
            copy_exp.transform.position = col.transform.position;
            Destroy(col.gameObject);//벽 없앰
            Destroy(copy_exp, dTime);
        }
        else if (col.gameObject.tag == "Enemy")
        {
            //Score.Counter++;// 클래스 전역변수
            //Debug.Log(Score.Counter);

            /*if (Score.Counter > 20)
            {
                Destroy(col.gameObject);
                Score.Count++; // 찾은 탱크 갯수
                Score.Counter = 0; // 탱크 여러개 여서 20 이 넘으면 초기화
                //SceneManager.LoadScene("Win");
            }*/
        }
        else if (col.gameObject.tag == "Target")
        {
            /*Score.Hit++;
            if (Score.Hit > 10)
            {
                Destroy(col.gameObject);
                Debug.Log("You Defeat!!");
                SceneManager.LoadScene("Lose");

            }
        }
        else if (Score.Ec == 0)
        {
            SceneManager.LoadScene("Win");
        }*/
            Destroy(copy_exp, dTime);
        }
    }
}

