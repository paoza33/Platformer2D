using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private PlayerHealth playerHealth;

    private void Awake() {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            other.transform.position = CurrentSceneManager.instance.respawnPoint;
            playerHealth.TakeDamage(50);
        }
    }
}
