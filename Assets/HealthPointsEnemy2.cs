using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPointsEnemy2 : MonoBehaviour
{
    int HP = 5;
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
        }
    }
}
