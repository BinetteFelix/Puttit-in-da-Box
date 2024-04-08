using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWithApple : MonoBehaviour
{
    bool IsActive = false;

    GameObject Player;
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
            if (Input.GetKeyDown(KeyCode.E))
            {
                Apple.DestroyApple();
                IsActive = false;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Player = collision.gameObject;
        Apple = Player.GetComponent<PickUpApple>();

        if (Apple != null)
        {
            IsActive = true;
            if (IsActive == true)
            {
                Apple.PressEtoPickUp();
            }
        }
        
    }

    private void OnCollisionExit(Collision collision)
    {
        Player = collision.gameObject;
        Apple = Player.GetComponent<PickUpApple>();


        if (Apple != null)
        {
            Apple.DestroyUI();
        }
        IsActive = false;
    }
}
