using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> Enemies;

    Vector3 Enemy1SpawnPoint = new Vector3(111, 41, 162.5f);
    Vector3 Enemy2SpawnPoint = new Vector3(7.5f, 41, 311);

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy1();
        SpawnEnemy2();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnEnemy1()
    {
        Instantiate(Enemies[0], Enemy1SpawnPoint, Quaternion.identity);
    }
    public void SpawnEnemy2()
    {
        Instantiate(Enemies[1], Enemy2SpawnPoint, Quaternion.identity);
    }
}
