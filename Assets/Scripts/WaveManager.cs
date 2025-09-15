using System.Collections;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject enemySpawn;

    private int maxWave = 5;
    [SerializeField] private int maxEnemy;
    private WaitForSeconds spawnBuffer = new WaitForSeconds(3f);
    public bool _isWaveActive;
    private bool _isWaveOver;
    [SerializeField] private int spawnedEnemies;

    public int currentWave;
    public int enemyCount;


    void Start()
    {
        enemySpawn.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {

        if (_isWaveActive)
        {
            StartCoroutine("SpawnRoutine");
            if (spawnedEnemies >= maxEnemy && enemyCount == 0)
            {
                EndWave();
            }
        }

    }

    public void StartWave()
    {
        _isWaveActive = true;
        if (currentWave < maxWave)
        { currentWave++; }
        Debug.Log("Wave has started? " + _isWaveActive + ", Current Wave: " + currentWave);
    }

    public void EndWave()
    {
        _isWaveActive = false;
        _isWaveOver = true;
        this.gameObject.SetActive(false);
    }

    IEnumerator SpawnRoutine()
    {
        while (spawnedEnemies < maxEnemy)
        {
            float rangeX = Random.Range(-40, 40);
            float rangeZ = Random.Range(-45, 45);
            Vector3 newSpawn = new(rangeX, 1f, rangeZ);

            Instantiate(enemySpawn, newSpawn, enemySpawn.transform.rotation);
            spawnedEnemies++;
            enemyCount++;
            yield return spawnBuffer;
        }
    }
}
