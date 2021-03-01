using UnityEngine;

public class CurrentSceneManager : MonoBehaviour
{
    public int coinsPickeUpInThisScene = 0;
    public static CurrentSceneManager instance;
    public Vector3 respawnPoint;
    public int levelToUnlock;
    private void Awake()
    {
        if(instance != null){
            Debug.LogWarning("il y a plus d'une instance de CurrentSceneManager");
            return;
        }
        instance = this;
        respawnPoint = GameObject.FindGameObjectWithTag("Player").transform.position;
    }
}
