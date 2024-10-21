using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{
    [SerializeField] GameObject Weapon;
    [SerializeField] Transform ADSPosition;
    [SerializeField] Transform DefaultPos;
    private float AnimationSpeed = 7.5f;

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Weapon.transform.position = Vector3.Slerp(Weapon.transform.position, ADSPosition.transform.position, AnimationSpeed * Time.deltaTime);
        }
        else
        {
            Weapon.transform.position = Vector3.Slerp(Weapon.transform.position, DefaultPos.transform.position, AnimationSpeed * Time.deltaTime);
        }

        

    }
}
