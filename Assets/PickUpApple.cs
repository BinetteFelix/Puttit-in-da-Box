using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpApple : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnCollisionStay(Collision collision)
    {
        GameObject NotPlayer = collision.gameObject;

        Movement Player = NotPlayer.GetComponent<Movement>();


        if (Player != null)
        {
            Player.PressEtoPickUp();
        }
    }
}
