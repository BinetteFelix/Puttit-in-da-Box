using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{
    public AnimationCurve MoveCurve;
    [SerializeField] GameObject Weapon;
    [SerializeField] Transform ADSPosition;
    [SerializeField] Transform DefaultPos;
    private float AnimationSpeed = 7.5f;
    private float _animationTimePosition;


    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            _animationTimePosition += Time.deltaTime;
            Weapon.transform.position = Vector3.Lerp(Weapon.transform.position, ADSPosition.transform.position, AnimationSpeed * Time.deltaTime);
        }
        else
        {
            Weapon.transform.position = Vector3.Lerp(Weapon.transform.position, DefaultPos.transform.position, AnimationSpeed * Time.deltaTime);
            _animationTimePosition = 0;
        }

    }
}
