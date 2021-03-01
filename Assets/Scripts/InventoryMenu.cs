using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenu : MonoBehaviour
{
    public static bool gameIsPaused;
    public GameObject inventoryMenuUI;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I)){
            if(gameIsPaused){
                Resume();
            }else{
                Paused();
            }
        }
    }
    void Paused(){
        inventoryMenuUI.SetActive(true);
        PlayerMovement.instance.enabled = false;
        Time.timeScale = 0;
        gameIsPaused = true;
    }
    public void Resume(){
        inventoryMenuUI.SetActive(false);
        PlayerMovement.instance.enabled = true;
        Time.timeScale = 1;
        gameIsPaused = false;
    }
    
}
