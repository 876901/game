using UnityEngine;
using System.Collections;

public class WaveManager :MonoBehaviour
{
    public GameObject enemyTankPrefab; // �� ��ũ ������
    public float waveInterval = 10f; // ���̺� ���� (��)
    public int enemiesPerWave = 5; // ���̺�� �����Ǵ� �� ��
    public float spawnDistanceMin = 20f; // �÷��̾�κ��� �ּ� ���� �Ÿ�
    public float spawnDistanceMax = 40f; // �÷��̾�κ��� �ִ� ���� �Ÿ�

    private bool isWaveActive = false;
    private int currentWave = 0;
    public GameObject player; // �÷��̾� ������Ʈ

    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Spawn");
        StartCoroutine(StartWaveRoutine());
    }

    IEnumerator StartWaveRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(waveInterval);
            StartWave();
            waveInterval = waveInterval / 2;
        }
    }

    void StartWave()
    {
        currentWave++;
        isWaveActive = true;
        if(currentWave <= 2) {
            StartCoroutine(SpawnEnemiesRoutine());
        }

        
    }

    IEnumerator SpawnEnemiesRoutine()
    {
        for (int i = 0; i < enemiesPerWave; i++)
        {
            Vector3 spawnDirection = Random.insideUnitSphere; // ���� ����
            spawnDirection.y = 0;
            float spawnDistance = Random.Range(spawnDistanceMin, spawnDistanceMax); // ���� �Ÿ�
            Vector3 spawnPosition = player.transform.position + spawnDirection * spawnDistance;
            Instantiate(enemyTankPrefab, spawnPosition, Quaternion.identity);
            spawnPosition.y = -7.4f; // Y�� ����

            yield return new WaitForSeconds(1f); // �� �� ���� ����
        }

        isWaveActive = false;
    }
}
