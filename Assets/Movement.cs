using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject Camera;
    int Speed = 10;
    public Vector3 Deltamove;
    bool SprintToggle = false;
    bool JumpCooldownActive = false;
    Rigidbody PlayerRigidbody;
    float SecondCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        PlayerRigidbody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Calls the method Gravity
        Gravity();
        Deltamove = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")) * Speed * Time.deltaTime;
        transform.Translate(Deltamove);

        if (SprintToggle == false)
        {
            //Movement
            if (Input.GetKey(KeyCode.W))
            {
                MoveForward();
            }
            if (Input.GetKey(KeyCode.A))
            {
                MoveForward();
            }
            if (Input.GetKey(KeyCode.S))
            {
                MoveForward();
            }
            if (Input.GetKey(KeyCode.D))
            {
                MoveForward();
            }
        }
        if(SprintToggle == true)
        {
            if (Input.GetKey(KeyCode.W))
            {
                SprintForward();
            }
            if (Input.GetKey(KeyCode.A))
            {
                SprintForward();
            }
            if (Input.GetKey(KeyCode.S))
            {
                SprintForward();
            }
            if (Input.GetKey(KeyCode.D))
            {
                SprintForward();
            }
        }
        if (Input.GetKey(KeyCode.LeftShift) && SprintToggle == false)
        {
            SprintToggle = true;
        }
        else if(Input.GetKey(KeyCode.LeftShift) && SprintToggle == true)
        {
            SprintToggle = false;
        }
        
        if(JumpCooldownActive == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }
        if(JumpCooldownActive == true)
        {
            SecondCount += Time.deltaTime;
        }
        if(SecondCount >= 0.99f)
        {
            SecondCount = 0;
            JumpCooldownActive = false;
        }
    }
    //Normal Move Script
    void MoveForward()
    {
        Speed = 10;
        PlayerRigidbody.AddForce(Deltamove, ForceMode.Impulse);
    }
    //Sprint Move Script
    void SprintForward()
    {
        Speed = 25;
        PlayerRigidbody.AddForce(Deltamove, ForceMode.Impulse);
    }
    //Jumping Script
    void Jump()
    {
        PlayerRigidbody.AddForce(new Vector3(0, 85, 0), ForceMode.Impulse);
        JumpCooldownActive = true;
    }
    //Gravity (Kinda obvious but anyway)
    void Gravity()
    {
        PlayerRigidbody.AddForce(new Vector3(0, -150, 0));
    }
}
