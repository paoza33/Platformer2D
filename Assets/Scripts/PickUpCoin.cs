using UnityEngine;

public class PickUpCoin : MonoBehaviour
{
    public AudioClip sound;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            AudioManager.instance.PlayClipAt(sound, transform.position);
            Inventory.instance.AddCoins(1);
            CurrentSceneManager.instance.coinsPickeUpInThisScene++;
            Destroy(gameObject);
        }
    }
}
