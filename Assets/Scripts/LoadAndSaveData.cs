using UnityEngine;

public class LoadAndSaveData : MonoBehaviour
{
    public static LoadAndSaveData instance;
    private void Awake()
    {
        if(instance != null){
            Debug.LogWarning("il y a plus d'une instance de LoadAndSaveData");
            return;
        }
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        // (,0) : CoinsCount aura pour valeur 0 par default
        // vérifier valeur prefab pour windows : Input windows+R -> taper "regedit" -> SOFTWARE -> Unity -> UnityEditor -> le nom de notre company -> le nom de notre projet
        // pour les supprimer (les données) aller sur Unity puis Edit -> Clear all PlayerPref
        Inventory.instance.coinsCount = PlayerPrefs.GetInt("CoinsCount",0);
        PlayerHealth.instance.currentHealth = PlayerPrefs.GetInt("PlayerLife",100);
        Inventory.instance.UpdateTextUI();
        foreach(Item item in Inventory.instance.content){
            Inventory.instance.countInventory[item.id].text = PlayerPrefs.GetString(item.name,"0");
        }
    }

    public void SaveData(){
        PlayerPrefs.SetInt("CoinsCount", Inventory.instance.coinsCount);
        PlayerPrefs.SetInt("PlayerLife", PlayerHealth.instance.currentHealth);
        if(CurrentSceneManager.instance.levelToUnlock > PlayerPrefs.GetInt("levelReached",0)){
            PlayerPrefs.SetInt("levelReached", CurrentSceneManager.instance.levelToUnlock);
        }
        foreach(Item item in Inventory.instance.content){
            PlayerPrefs.SetString(item.name, Inventory.instance.countInventory[item.id].text);
        }
    }
}
