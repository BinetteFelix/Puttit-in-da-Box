using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPointsEnemy2 : MonoBehaviour
{
    [SerializeField]
    GameObject Banana;

    int HP = 5;

    Vector3 SpawnOffset = new Vector3(0, 15, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage()
    {
        HP -= 1;
        if (HP == 0)
        {
            Destroy(gameObject);
            Instantiate(Banana, gameObject.transform.position + SpawnOffset, Quaternion.identity);
        }
    }
    public void RespawnEnemy()
    {
        Destroy(gameObject);
        HP = 5;
    }
}
