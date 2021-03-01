using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public static GameOverManager instance;
    private void Awake()
    {
        if(instance != null){
            Debug.LogWarning("il y a plus d'une instance de GameOverManager");
            return;
        }
        instance = this;
    }
    public void onPlayerDeath(){
        gameOverUI.SetActive(true);
    }
    public void RetryButton(){
        //recharger la scène
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerHealth.instance.Respawn();
        Inventory.instance.RemoveCoins(CurrentSceneManager.instance.coinsPickeUpInThisScene);
        gameOverUI.SetActive(false);
    }
    public void MainMenuButton(){
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitButton(){
        Application.Quit();
    }
}
