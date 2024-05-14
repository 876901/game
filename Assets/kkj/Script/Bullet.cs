using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    public int power = 1700;
    private float dTime = 3.0f;
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

    }   
}

