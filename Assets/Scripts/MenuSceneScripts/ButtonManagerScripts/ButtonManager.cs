using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] GameObject SettingsPanel;
    [SerializeField] GameObject MenuCanvas;
    [SerializeField] GameObject PauseCanvas;

    private void Start()
    {
        Time.timeScale = 0;
    }
    private void Update()
    {
        if(Time.timeScale == 0)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
    public void LoadGame()
    {
        MenuCanvas.SetActive(false);
        Time.timeScale = 1;
    }
    public void OpenMainMenu()
    {
        PauseCanvas.SetActive(false);
        MenuCanvas.SetActive(true);
        Time.timeScale = 0;
    }
    public void UnPauseGame()
    {
        PauseCanvas.SetActive(false);
        Time.timeScale = 1;
    }
    public void OpenSettingsMenu()
   {
        SettingsPanel.SetActive(true);
   }
   public void CloseSettingsMenu()
   {
       SettingsPanel.SetActive(false);
   }
    public void QuitGame()
   {
        Application.Quit();
   }
}
