using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    //외부에서 세팅한변수
    //public GameObject target;
    //public GameObject bullet;//총알 오브젝트
    //public GameObject spPoint;//총알 나가는 포인트
    //public AudioClip snd; 사운드 오브젝트

    //내부적으로 쓰이는 변수
    private Transform target; //아군 탱크의 위치 저장
    private int rotAngle; //적 탱크의 회전 각도 
    private float amtToRot; // 적 탱크의 회전 
    private int power; // 총알이 나가는 힘 
    private float distance; // 아군태크와 적탱크 사이의 거리 
    private Vector3 direction; //적탱크가 아군 탱크를 바라보는 방향
    private float moveSpeed; // 적탱크의 이동속도
    private float fTime; // 총알이 나가는 시간 

    private NavMeshAgent nvAgent;
    public GameObject EspPoint;
    public GameObject bulletPrefab;
    public GameObject turret;
    private Transform spPoint;
    //public GameObject tar;




    // Start is called before the first frame update
    void Start()
    {
        //gameObject myTank = GameObject("Tank")  ?? 교수님이 따로 적어주신거 맞는지 모르겠음
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
        // 이후의 코드에서 target을 사용할 수 있습니다.
    }

    // Update is called once per frame
    void Update()
    {

        #region 실습 
        /*
        //transform.LookAt(target.transform.position);
        //총알이 챙크쪽으로 나가는 방향을 알아냄
        direction = target.transform.position - this.transform.position;
        distance = Vector3.Distance(target.transform.position, this.transform.position);
        fTime += Time.deltaTime;
        if(distance < 15.0f)
        {
            //적탱크 따라오기 구현 
            this.transform.LookAt(target.transform.position);
            amtToRot = rotAngle * Time.deltaTime;
            transform.RotateAround(Vector3.zero, Vector3.up, amtToRot);
            this.transform.position = Vector3.Lerp( //부드럽게 해주는 함수 
                transform.position,// 시작점
                target.position, //끝점
                Time.deltaTime * moveSpeed / 2);//일정한 거리
            nvAgent.SetDestination(target.position);
            if (fTime > 0.5f)
            {
                //총알생성 (총알프리펩, 총알생성, 위치값, 총알 생성 회전값)
                GameObject obj = Instantiate(bullet, spPoint.transform.position, spPoint.transform.rotation) as GameObject;
                //obj.transform.position = spPoint.transform.position;
                obj.GetComponent<Rigidbody>().AddForce(direction * power);
                //사운드 처리 
                fTime = 0.0f;
            }
        }*/
        #endregion
        /*
        direction = target.transform.position - this.transform.position; //타겟으로 향하는 방향을 계산합니다. target와 this의 위치를 빼면 현재 객체에서 타겟까지의 방향이 얻어집니다.
        distance = Vector3.Distance(target.transform.position, this.transform.position);//현재 객체와 타겟 사이의 거리를 계산합니다. 이는 두 점 사이의 유클리드 거리를 계산하여 얻어집니다.
        */
        
        distance = Vector3.Distance(target.transform.position, this.transform.position);//현재 객체와 타겟 사이의 거리를 계산합니다. 이는 두 점 사이의 유클리드 거리를 계산하여 얻어집니다.
        fTime += Time.deltaTime;
        //direction = target.transform.position - this.transform.position;
        if (distance < 1000.0f)
        {

            nvAgent.SetDestination(target.position);
            //nvAgent.speed = 0.2f; // 느리게 따라온다
            if (fTime > 5.0f)
            {

                GameObject bullet = Instantiate(bulletPrefab, spPoint.position, spPoint.rotation) as GameObject; // 두번째, 세번째 인자는 비워져있어도 unity에서 지정한 위치값, 회전값을 지정 함 
                Rigidbody bulletAddforce = bullet.GetComponent<Rigidbody>(); // 리지드 바디 가져오기 bullet에서
                bulletAddforce.AddForce(turret.transform.forward * power); // turret 게임 오브젝트의 전방 방향으로 power만큼 발사
                                                                           //Destroy(bullet, DestroyTime);
                                                                           //ontriggerEnter 에 서 함수 Destroy 무조건 실행 ! 지워도됨 

                fTime = 0.0f;

            }
        }

    }
}
