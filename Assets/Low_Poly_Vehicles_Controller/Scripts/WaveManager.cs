using UnityEngine;
using System.Collections;

public class WaveManager : MonoBehaviour
{
    public GameObject enemyTankPrefab; // 적 탱크 프리팹
    public float waveInterval = 1f; // 웨이브 간격 (초)
    public int enemiesPerWave = 5; // 웨이브당 생성되는 적 수
    public float spawnDistanceMin = 20f; // 플레이어로부터 최소 생성 거리
    public float spawnDistanceMax = 40f; // 플레이어로부터 최대 생성 거리

    private bool isWaveActive = false;
    private int currentWave = 0;
    private GameObject player; // 플레이어 오브젝트

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Spawn");
        StartCoroutine(StartWaveRoutine());
    }

    IEnumerator StartWaveRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(waveInterval);
            StartWave();
        }
    }

    void StartWave()
    {
        currentWave++;
        isWaveActive = true;

        StartCoroutine(SpawnEnemiesRoutine());
    }

    IEnumerator SpawnEnemiesRoutine()
    {
        for (int i = 0; i < enemiesPerWave; i++)
        {
            Vector3 spawnDirection = Random.insideUnitSphere; // 랜덤 방향
            float spawnDistance = Random.Range(spawnDistanceMin, spawnDistanceMax); // 랜덤 거리
            Vector3 spawnPosition = player.transform.position + spawnDirection * spawnDistance;
            Instantiate(enemyTankPrefab, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(1f); // 각 적 생성 간격
        }

        isWaveActive = false;
    }
}
