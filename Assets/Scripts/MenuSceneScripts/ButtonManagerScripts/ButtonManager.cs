using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    GameObject SettingsPanel;
   public void LoadGame()
   {
        SceneManager.LoadScene(1);
   }
   public void OpenSettingsMenu()
   {
        SettingsPanel.SetActive(true);
   }
   public void QuitGame()
   {
        Application.Quit();
   }
}
