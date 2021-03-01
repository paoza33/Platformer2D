using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class Inventory : MonoBehaviour
{
    public int coinsCount;
    public Text coinsCountText;

    //inventory permet d'avoir une classe dite singleton
    public static Inventory instance;
    public List<Item> content = new List<Item>();
    public List<Text> countInventory = new List<Text>();
    public PlayerEffect playerEffect;
    private void Awake()
    {
        if(instance != null){
            Debug.LogWarning("il y a plus d'une instance de Inventory");
            return;
        }
        instance = this;
    }
    public void ConsumeItem(int indexInventory){
        int number;
        bool isParsable = Int32.TryParse(countInventory[indexInventory].text, out number);
        if(isParsable)
        {
            if(!(number <= 0)){
                Item currentItem = content[indexInventory];
                PlayerHealth.instance.HealPlayer(currentItem.hpGiven);
                playerEffect.AddSpeed(currentItem.speedGiven, currentItem.speedDuration);
                number--;
                countInventory[indexInventory].text = number.ToString();
            }
        }
        else{ Debug.LogWarning("Could not be parsed."); }
    }
    public void AddItem(int id){
        int number;
        bool isParsable = Int32.TryParse(countInventory[id].text, out number);
        if(isParsable){
            number++;
            countInventory[id].text = number.ToString();
        }
        else{ Debug.LogWarning("Could not be parsed."); }
    }

    public void AddCoins(int count){
        coinsCount += count;
        UpdateTextUI();
    }
    public void RemoveCoins(int count){
        if(count <= coinsCount){
            coinsCount -= count;
            UpdateTextUI();
            // pas optimale du tout mais fait l'affaire pour l'instant
            if(count == 5){
               AddItem(0);
            }
            else if(count == 3){
                AddItem(1);
            }
        }
    }
    public void UpdateTextUI(){
        coinsCountText.text = coinsCount.ToString();
    }
}
