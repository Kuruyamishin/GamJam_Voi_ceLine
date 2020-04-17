using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float spawnTime;
    public float spawnTimeMax;
    public GameObject enemyPrefab;
    public bool isDead = false;

    public Transform[] spawner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            if (spawnTime < spawnTimeMax)
            {
                spawnTime += Time.deltaTime;
            }
            else if (spawnTime >= spawnTimeMax)
            {
                int rand1 = Random.Range(0, 7);
                int rand2 = Random.Range(0, 7);
                int rand3 = Random.Range(0, 7);

                GameObject foe1 = Instantiate(enemyPrefab, spawner[rand1].position, transform.rotation);
                GameObject foe2 = Instantiate(enemyPrefab, spawner[rand2].position, transform.rotation);
                GameObject foe3 = Instantiate(enemyPrefab, spawner[rand3].position, transform.rotation);

                spawnTime = 0;
            }
        }
    }
}
