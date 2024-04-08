using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWithApple : MonoBehaviour
{
    bool IsActive = false;

    GameObject NotApple;
    PickUpApple Apple;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(IsActive == true)
        {
            if (Input.GetKey(KeyCode.E))
            {
                Apple.DestroyApple();
                Apple.DestroyUI();
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        NotApple = collision.gameObject;
        Apple = NotApple.GetComponent<PickUpApple>();

        if (Apple != null)
        {
            Apple.PressEtoPickUp();
        }
        IsActive = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        NotApple = collision.gameObject;
        Apple = NotApple.GetComponent<PickUpApple>();


        if (Apple != null)
        {
            Apple.DestroyUI();
        }
        IsActive = false;
    }
}
