using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class UIForItem : MonoBehaviour
{
    //if the UI is active or not
    bool IsActive = false;

    public TextMeshProUGUI PressEText;
    //Actual image
    public Image PressEPrefab;
    //Used for spawning to work
    private Image UIUse;

    private TextMeshProUGUI TextUse;

    Vector3 SpawnOffset = new Vector3(50, 0, 0);

    // Update is called once per frame
    void Update()
    {
        if(IsActive == true)
        {
            UIUse.transform.position = Camera.main.WorldToScreenPoint(transform.position) + SpawnOffset;
            TextUse.transform.position = Camera.main.WorldToScreenPoint(transform.position) + SpawnOffset;
        }
    }
    public void ShowUI()
    {
        IsActive = true;
        UIUse = Instantiate(PressEPrefab, FindObjectOfType<Canvas>().transform).GetComponent<Image>();
        TextUse = Instantiate(PressEText, FindObjectOfType<Canvas>().transform).GetComponent<TextMeshProUGUI>();
    }

    public void DestroyUI()
    {
        IsActive = false;
        Destroy(UIUse);
        Destroy(TextUse);
    }
}
