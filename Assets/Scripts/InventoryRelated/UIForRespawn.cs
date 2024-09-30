using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    public TextMeshProUGUI PressEText;

    private TextMeshProUGUI TextUse;

    Vector3 SpawnOffset = new Vector3(50, 0, 0);

    public List<GameObject> Enemies;

    Vector3 Enemy1SpawnPoint = new Vector3(0, 0, 175);
    Vector3 Enemy2SpawnPoint = new Vector3(25, 0, 175);
    Vector3 Enemy3SpawnPoint = new Vector3(50, 0, 175);
    Vector3 Enemy4SpawnPoint = new Vector3(75, 0, 175);
    Vector3 Enemy5SpawnPoint = new Vector3(100, 0, 175);
    Vector3 Enemy6SpawnPoint = new Vector3(125, 0, 175);

    HealthPointsEnemy1 Healthpoints1;
    HealthPointsEnemy1 Healthpoints2;

    public GameObject Enemy1;
    public GameObject Enemy2;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Enemies[0], Enemy1SpawnPoint, Quaternion.identity);
        Instantiate(Enemies[1], Enemy2SpawnPoint, Quaternion.identity);
        Instantiate(Enemies[2], Enemy3SpawnPoint, Quaternion.identity);
        Instantiate(Enemies[3], Enemy4SpawnPoint, Quaternion.identity);
        Instantiate(Enemies[4], Enemy5SpawnPoint, Quaternion.identity);
        Instantiate(Enemies[5], Enemy6SpawnPoint, Quaternion.identity);
    }

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
    public void Respawn()
    {
        Instantiate(Enemy1, Enemy1SpawnPoint, Quaternion.identity);
        Instantiate(Enemy2, Enemy2SpawnPoint, Quaternion.identity);
        Instantiate(Enemy1, Enemy3SpawnPoint, Quaternion.identity);
        Instantiate(Enemy2, Enemy4SpawnPoint, Quaternion.identity);
        Instantiate(Enemy1, Enemy5SpawnPoint, Quaternion.identity);
        Instantiate(Enemy2, Enemy6SpawnPoint, Quaternion.identity);
    }
}
