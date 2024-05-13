using UnityEngine;
using System.Collections;

public class WaveManager : MonoBehaviour
{
    public GameObject enemyTankPrefab; // �� ��ũ ������
    public float waveInterval = 1f; // ���̺� ���� (��)
    public int enemiesPerWave = 5; // ���̺�� �����Ǵ� �� ��
    public float spawnDistanceMin = 20f; // �÷��̾�κ��� �ּ� ���� �Ÿ�
    public float spawnDistanceMax = 40f; // �÷��̾�κ��� �ִ� ���� �Ÿ�

    private bool isWaveActive = false;
    private int currentWave = 0;
    private GameObject player; // �÷��̾� ������Ʈ

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
            Vector3 spawnDirection = Random.insideUnitSphere; // ���� ����
            float spawnDistance = Random.Range(spawnDistanceMin, spawnDistanceMax); // ���� �Ÿ�
            Vector3 spawnPosition = player.transform.position + spawnDirection * spawnDistance;
            Instantiate(enemyTankPrefab, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(1f); // �� �� ���� ����
        }

        isWaveActive = false;
    }
}
