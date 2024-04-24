using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class UIForRespawn : MonoBehaviour
{
    //if the UI is active or not
    bool IsActive = false;

    //Actual image
    public Image PressEPrefab;
    //Used for spawning to work
    private Image UIUse;

    Vector3 SpawnOffset = new Vector3(50, 0, 0);

    public List<GameObject> Enemies;

    Vector3 Enemy1SpawnPoint = new Vector3(111, 41, 162.5f);
    Vector3 Enemy2SpawnPoint = new Vector3(7.5f, 41, 311);

    HealthPointsEnemy1 Healthpoints1;
    HealthPointsEnemy1 Healthpoints2;

    public GameObject Enemy1;
    public GameObject Enemy2;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Enemies[0], Enemy1SpawnPoint, Quaternion.identity);
        Instantiate(Enemies[1], Enemy2SpawnPoint, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if(IsActive == true)
        {
            UIUse.transform.position = Camera.main.WorldToScreenPoint(transform.position) + SpawnOffset;
        }
    }

    public void ShowUI()
    {
        IsActive = true;
        UIUse = Instantiate(PressEPrefab, FindObjectOfType<Canvas>().transform).GetComponent<Image>();
    }

    public void DestroyUI()
    {
        IsActive = false;
        Destroy(UIUse);
    }
    public void Respawn()
    {
        Instantiate(Enemy1, Enemy1SpawnPoint, Quaternion.identity);
        Instantiate(Enemy2, Enemy2SpawnPoint, Quaternion.identity);
    }
}
