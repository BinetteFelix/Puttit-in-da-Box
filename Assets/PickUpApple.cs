using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class PickUpApple : MonoBehaviour
{
    bool IsActive = false;

    public Image PressEPrefab;
    private Image UIUse;

    Rigidbody AppleRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        AppleRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(IsActive == true)
        {
            UIUse.transform.position = Camera.main.WorldToScreenPoint(transform.position);
        }
        AppleRigidbody.AddForce(new Vector3(0, -25, 0));
    }

    public void PressEtoPickUp()
    {
        IsActive = true;
        UIUse = Instantiate(PressEPrefab, FindObjectOfType<Canvas>().transform).GetComponent<Image>();
    }
    public void DestroyUI()
    {
        IsActive = false;
        Destroy(UIUse);
    }
    public void DestroyApple()
    {
        Destroy(gameObject);
    }
}
