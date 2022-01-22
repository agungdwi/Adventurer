using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    public GameObject enemy;
    Vector2 whereToSpawn;
    public float spawnRate = 10f;
    float nextSpawn = 0.0f;
    public float harder = 0.2f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn){
            nextSpawn = Time.time + spawnRate;
            whereToSpawn = new Vector2 (transform.position.x,transform.position.y);
            Instantiate (enemy, whereToSpawn, Quaternion.identity);

            if (spawnRate >= 5f) {
                spawnRate -= harder;
                if (harder < 2) {
                    harder += 0.4f;
                    FollowAi.AttackUp();
                }
            }

        }

        
    }
}
