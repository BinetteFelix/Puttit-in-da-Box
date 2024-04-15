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
                Apple.DestroyUI();
                IsActive = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Player = other.gameObject;
        Apple = Player.GetComponent<PickUpApple>();

        if (Apple != null)
        {
            Apple.PressEtoPickUp();
        }
        IsActive = true;
    }
    private void OnTriggerExit(Collider other)
    {
        Player = other.gameObject;
        Apple = Player.GetComponent<PickUpApple>();

        if (Apple != null)
        {
            Apple.DestroyUI();
        }
        IsActive = false;
    }
}
