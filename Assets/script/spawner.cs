using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class spawner : MonoBehaviour
{
    public GameObject prefab;
    public GameObject prefab2;
    public player playerScript; // Inspector'dan atayın

    public void Start() {
        InvokeRepeating(nameof(spawncube), 0f, 3f);
    }

    public void spawncube()
    {
        // prefab her zaman doğar
        Vector3 spawnPoint = new Vector3();
        spawnPoint.x = Random.Range(-3, 3);
        spawnPoint.y = Random.Range(-3, 3);
        Instantiate(prefab, spawnPoint, quaternion.identity);

        // prefab2 sadece level 2 ve üstünde doğar
        if (playerScript != null && playerScript.level >= 2)
        {
            spawnPoint.x = Random.Range(-3, 3);
            spawnPoint.y = Random.Range(-3, 3);
            Instantiate(prefab2, spawnPoint, quaternion.identity);
        }
    }

    void Update()
    {

    }
}


