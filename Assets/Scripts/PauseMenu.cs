using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused;
    public GameObject pausedMenuUi;
    public GameObject settingsWindow;
    private bool SettingsWindowIsClosed = true;
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(gameIsPaused){
                Resume();
            }else{
                Paused();
            }
        }
    }
    public void Resume(){
        if(!SettingsWindowIsClosed){
            CloseSettingsWindow();
        }
        pausedMenuUi.SetActive(false);
        PlayerMovement.instance.enabled = true;
        Time.timeScale = 1;
        gameIsPaused = false;
    }
    void Paused(){
        pausedMenuUi.SetActive(true);
        PlayerMovement.instance.enabled = false;
        Time.timeScale = 0;
        gameIsPaused = true;
    }

    public void LoadMainMenu(){
        Resume();
        SceneManager.LoadScene("MainMenu");
    }

    public void SettingsWindow(){
        settingsWindow.SetActive(true);
        SettingsWindowIsClosed = false;
    }
    public void CloseSettingsWindow(){
        SettingsWindowIsClosed = true;
        settingsWindow.SetActive(false);
    }
}
