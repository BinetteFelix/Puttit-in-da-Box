using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWithApple : MonoBehaviour
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
        GameObject NotApple = collision.gameObject;

        PickUpApple Apple = NotApple.GetComponent<PickUpApple>();


        if (Apple != null)
        {
            Apple.PressEtoPickUp();
        }
    }
}
