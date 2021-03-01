﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public Button[] levelButtons;
    private void Start() {
        
        int levelReached = PlayerPrefs.GetInt("levelReached",1);
        for(int i = levelReached; i < levelButtons.Length; i++){
            levelButtons[i].interactable = false;
        }
    }
    public void LevelSelected(string level){
        SceneManager.LoadScene(level);
    }
}
