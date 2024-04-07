using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class PickUpApple : MonoBehaviour
{

    public Image PressEPrefab;
    private Image UIUse;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UIUse.transform.position = Camera.main.WorldToScreenPoint(transform.position);
    }

    public void PressEtoPickUp()
    {
        UIUse = Instantiate(PressEPrefab, FindObjectOfType<Canvas>().transform).GetComponent<Image>();
    }
    public void DestroyApple()
    {
        Destroy(UIUse);
    }
}
