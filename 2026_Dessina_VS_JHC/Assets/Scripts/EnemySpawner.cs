using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2.0f;
    public float spawnRange = 13.0f;

    private float timer = 0.0f;


    void Update()
    {
        timer += Time.deltaTime;

        if(timer > spawnInterval )
        {
            SpawnEnemy();
            timer = 0.0f;
        }
    }

    private void SpawnEnemy()
    {
        Vector3 spawnposition = GetRandomEdgePosition();
        Instantiate(enemyPrefab, spawnposition, Quaternion.identity);
    }

    private Vector3 GetRandomEdgePosition()
    {
        int side = Random.Range(0, 4);

        float x = 0.0f;
        float z = 0.0f;

        switch(side)
        {
            case 0:
                x = Random.Range(-spawnRange, spawnRange);
                z = spawnRange;
                break;
            case 1:
                x = Random.Range(-spawnRange, spawnRange);
                z = -spawnRange;
                break;
            case 2:
                x = Random.Range(-spawnRange, spawnRange);
                z = spawnRange;
                break;
            case 3:
                x = spawnRange;
                z = Random.Range(-spawnRange, spawnRange);
                break;
            case 4:
                x = -spawnRange;
                z = Random.Range(-spawnRange, spawnRange);
                break;
        }

        return new Vector3(x, 0.5f, z);
    }
}
