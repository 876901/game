using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    public int power = 1700;
    private float dTime = 3.0f;
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

    }   
}

