using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class UIForItem : MonoBehaviour
{
    //if the UI is active or not
    bool IsActive = false;

    //Actual image
    public Image PressEPrefab;
    //Used for spawning to work
    private Image UIUse;

    Vector3 SpawnOffset = new Vector3(50, 0, 0);

    // Update is called once per frame
    void Update()
    {
        if(IsActive == true)
        {
            UIUse.transform.position = Camera.main.WorldToScreenPoint(transform.position) + SpawnOffset;
        }
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
}
