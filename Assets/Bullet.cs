using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)                                                      
    {
        GameObject NotEnemy = collision.gameObject;

        HealthPointsEnemy1 Enemy1 = NotEnemy.GetComponent<HealthPointsEnemy1>();
        HealthPointsEnemy2 Enemy2 = NotEnemy.GetComponent<HealthPointsEnemy2>();

        if (Enemy1 != null)
        {
            Enemy1.TakeDamage();
        }
        else if (Enemy2 != null)
        {
            Enemy2.TakeDamage();
        }
        Destroy(gameObject);
    }
}
