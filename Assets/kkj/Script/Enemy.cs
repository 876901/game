using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    //�ܺο��� �����Ѻ���
    //public GameObject target;
    //public GameObject bullet;//�Ѿ� ������Ʈ
    //public GameObject spPoint;//�Ѿ� ������ ����Ʈ
    //public AudioClip snd; ���� ������Ʈ

    //���������� ���̴� ����
    private Transform target; //�Ʊ� ��ũ�� ��ġ ����
    private int rotAngle; //�� ��ũ�� ȸ�� ���� 
    private float amtToRot; // �� ��ũ�� ȸ�� 
    private int power; // �Ѿ��� ������ �� 
    private float distance; // �Ʊ���ũ�� ����ũ ������ �Ÿ� 
    private Vector3 direction; //����ũ�� �Ʊ� ��ũ�� �ٶ󺸴� ����
    private float moveSpeed; // ����ũ�� �̵��ӵ�
    private float fTime; // �Ѿ��� ������ �ð� 

    private NavMeshAgent nvAgent;
    public GameObject EspPoint;
    public GameObject bulletPrefab;
    public GameObject turret;
    private Transform spPoint;
    //public GameObject tar;




    // Start is called before the first frame update
    void Start()
    {
        //gameObject myTank = GameObject("Tank")  ?? �������� ���� �����ֽŰ� �´��� �𸣰���
        //Invoke("FindTarget", 1f);

        //target = GameObject.FindGameObjectWithTag("Target").GetComponent<Transform>();
        //target = tar.GetComponent<Transform>();

        moveSpeed = 1.0f;
        power = 5000;
        fTime = 0.0f;
        rotAngle = 15;
        nvAgent = this.GetComponent<NavMeshAgent>();
        spPoint = EspPoint.GetComponent<Transform>();
        target = GameObject.FindGameObjectWithTag("Vehicles").GetComponent<Transform>();

    }
    void FindTarget()
    {
        target = GameObject.FindGameObjectWithTag("Vehicles").GetComponent<Transform>();
        // ������ �ڵ忡�� target�� ����� �� �ֽ��ϴ�.
    }

    // Update is called once per frame
    void Update()
    {

        #region �ǽ� 
        /*
        //transform.LookAt(target.transform.position);
        //�Ѿ��� ìũ������ ������ ������ �˾Ƴ�
        direction = target.transform.position - this.transform.position;
        distance = Vector3.Distance(target.transform.position, this.transform.position);
        fTime += Time.deltaTime;
        if(distance < 15.0f)
        {
            //����ũ ������� ���� 
            this.transform.LookAt(target.transform.position);
            amtToRot = rotAngle * Time.deltaTime;
            transform.RotateAround(Vector3.zero, Vector3.up, amtToRot);
            this.transform.position = Vector3.Lerp( //�ε巴�� ���ִ� �Լ� 
                transform.position,// ������
                target.position, //����
                Time.deltaTime * moveSpeed / 2);//������ �Ÿ�
            nvAgent.SetDestination(target.position);
            if (fTime > 0.5f)
            {
                //�Ѿ˻��� (�Ѿ�������, �Ѿ˻���, ��ġ��, �Ѿ� ���� ȸ����)
                GameObject obj = Instantiate(bullet, spPoint.transform.position, spPoint.transform.rotation) as GameObject;
                //obj.transform.position = spPoint.transform.position;
                obj.GetComponent<Rigidbody>().AddForce(direction * power);
                //���� ó�� 
                fTime = 0.0f;
            }
        }*/
        #endregion
        /*
        direction = target.transform.position - this.transform.position; //Ÿ������ ���ϴ� ������ ����մϴ�. target�� this�� ��ġ�� ���� ���� ��ü���� Ÿ�ٱ����� ������ ������ϴ�.
        distance = Vector3.Distance(target.transform.position, this.transform.position);//���� ��ü�� Ÿ�� ������ �Ÿ��� ����մϴ�. �̴� �� �� ������ ��Ŭ���� �Ÿ��� ����Ͽ� ������ϴ�.
        */
        
        distance = Vector3.Distance(target.transform.position, this.transform.position);//���� ��ü�� Ÿ�� ������ �Ÿ��� ����մϴ�. �̴� �� �� ������ ��Ŭ���� �Ÿ��� ����Ͽ� ������ϴ�.
        fTime += Time.deltaTime;
        //direction = target.transform.position - this.transform.position;
        if (distance < 1000.0f)
        {

            nvAgent.SetDestination(target.position);
            //nvAgent.speed = 0.2f; // ������ ����´�
            if (fTime > 5.0f)
            {

                GameObject bullet = Instantiate(bulletPrefab, spPoint.position, spPoint.rotation) as GameObject; // �ι�°, ����° ���ڴ� ������־ unity���� ������ ��ġ��, ȸ������ ���� �� 
                Rigidbody bulletAddforce = bullet.GetComponent<Rigidbody>(); // ������ �ٵ� �������� bullet����
                bulletAddforce.AddForce(turret.transform.forward * power); // turret ���� ������Ʈ�� ���� �������� power��ŭ �߻�
                                                                           //Destroy(bullet, DestroyTime);
                                                                           //ontriggerEnter �� �� �Լ� Destroy ������ ���� ! �������� 

                fTime = 0.0f;

            }
        }

    }
}
