using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Bullet : MonoBehaviour
{
    public int power = 1700;
    private float dTime = 2.0f;
    public AudioClip sound; //��� ���� ����
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

        AudioSource.PlayClipAtPoint(sound, this.transform.position);// transform.position ��ġ���� ���
        GameObject copy_exp = Instantiate(exp) as GameObject;
        copy_exp.transform.position = this.transform.position;
        Destroy(gameObject);
        //col �� Wall �±׿� �ε�ġ�� 
        //���� �Ѿ��� ���ش� 

        if (col.gameObject.tag == "Wall")
        {
            copy_exp.transform.position = col.transform.position;
            Destroy(col.gameObject);//�� ����
            Destroy(copy_exp, dTime);
        }
        else if (col.gameObject.tag == "Enemy")
        {
            //Score.Counter++;// Ŭ���� ��������
            //Debug.Log(Score.Counter);

            /*if (Score.Counter > 20)
            {
                Destroy(col.gameObject);
                Score.Count++; // ã�� ��ũ ����
                Score.Counter = 0; // ��ũ ������ ���� 20 �� ������ �ʱ�ȭ
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

