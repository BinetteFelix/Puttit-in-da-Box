using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class Movement : MonoBehaviour
{
    public GameObject Weapon;
    [SerializeField] GameObject Inventory;
    [SerializeField] GameObject BulletPosition;
    [SerializeField] GameObject PauseCanvas;

    Rigidbody PlayerRigidbody;
    public Rigidbody BulletPrefab;
    public Transform OriginalPos;
    public Transform LeftPos;
    public Transform RightPos;
   
    Vector3 Deltamove;
    bool SprintToggle = false;
    bool JumpCooldownActive = false;
    public bool InventoryUI = false;

    int Speed = 25;
    float ShotSpeed = 250;
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
        //Move Direction
        Deltamove = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")) * Speed * Time.deltaTime;
        transform.Translate(Deltamove);


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
         
        //No Sprint Movement
        if (SprintToggle == false)
        {
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
        //Sprint Movement
        if (SprintToggle == true)
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

        if (InventoryUI == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ShootBullet();
            }

            if (Input.GetKeyDown(KeyCode.LeftShift) && SprintToggle == false)
            {
                SprintToggle = true;
            }
            else if(Input.GetKeyUp(KeyCode.LeftShift) && SprintToggle == true)
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
            if(SecondCount >= 0.75f)
            {
                SecondCount = 0;
                JumpCooldownActive = false;
            }
            CloseInventory();

            if (Input.GetKeyDown(KeyCode.Tab))
            {
                OpenInventory();
                InventoryManager.Instance.ArrangeItems();
            }
        }
        else if (InventoryUI == true)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                InventoryUI = false;
            }
            
        }
    }

    //Normal Move Script
    void MoveForward()
    {
        Speed = 25;
        PlayerRigidbody.AddForce(Deltamove, ForceMode.Impulse);
    }
    //Sprint Move Script
    void SprintForward()
    {
        Speed = 40;
        PlayerRigidbody.AddForce(Deltamove, ForceMode.Impulse);
    }

    //Jumping Script
    void Jump()
    {
        PlayerRigidbody.AddForce(new Vector3(0, 200, 0), ForceMode.Impulse);
        JumpCooldownActive = true;
    }
    //Gravity (Kinda obvious but anyway)
    void Gravity()
    {
        PlayerRigidbody.AddForce(new Vector3(0, -350, 0));

    }

    //Spawn- and Shoot bullet
    void ShootBullet()
    {
        var Projectile = Instantiate(BulletPrefab, BulletPosition.transform.position, BulletPosition.transform.localRotation);

        Projectile.velocity = BulletPosition.transform.forward * ShotSpeed;
    }

    public void OpenInventory()
    {
        Inventory.SetActive(true);
        InventoryUI = true;
    }
    public void CloseInventory()
    {
        Inventory.SetActive(false);
        InventoryUI = false;
    }
    public void PauseGame()
    {
        PauseCanvas.SetActive(true);
        Time.timeScale = 0;
    }
}
