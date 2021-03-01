using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public string sceneToLoad;
    public GameObject settingsWindow;
    public void StartGame(){
        SceneManager.LoadScene(sceneToLoad);
    }
    public void SettingsButton(){
        settingsWindow.SetActive(true);
    }

    public void CloseSettingsWindow(){
        settingsWindow.SetActive(false);
    }
    public void QuitGame(){
        Application.Quit();
    }
}
