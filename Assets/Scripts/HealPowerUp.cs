using UnityEngine;

public class HealPowerUp : MonoBehaviour
{
    public int healHeart;
    private void OnTriggerEnter2D(Collider2D other) {
        if(PlayerHealth.instance.currentHealth < PlayerHealth.instance.maxHealth){
            if(other.CompareTag("Player")){
                PlayerHealth.instance.HealPlayer(healHeart);
                Destroy(gameObject);
            }
        }
    }
}
