using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public bool isInvincible = false;
    public SpriteRenderer spriteRenderer;
    public AudioClip hitSound;

    public static PlayerHealth instance;
    private void Awake()
    {
        if(instance != null){
            Debug.LogWarning("il y a plus d'une instance de PlayerHealth");
            return;
        }
        instance = this;
    }

    void Start()
    {
        if(currentHealth < 100 && currentHealth != 0){
            healthBar.SetHealth(currentHealth);
        }
        else{
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H)){
            TakeDamage(100);
        }
        healthBar.SetHealth(currentHealth);
    }

    public void TakeDamage(int damage){
        if(!isInvincible){
            AudioManager.instance.PlayClipAt(hitSound, transform.position);
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            if(currentHealth <=0){
                Die();
                return;
            }
            isInvincible = true;
            StartCoroutine(InvincibilityFlash());
            StartCoroutine(HandleInvisibilityDelay());
        }
    }

    public void HealPlayer(int amount){
        currentHealth += amount;
        if(currentHealth > maxHealth){
            currentHealth = maxHealth;
        }
        healthBar.SetHealth(currentHealth);
    }

    public void Die(){
        PlayerMovement.instance.enabled = false;
        PlayerMovement.instance.animator.SetTrigger("Die");
        PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Kinematic;
        PlayerMovement.instance.rb.velocity = Vector3.zero;
        PlayerMovement.instance.playerCollider.enabled = false;
        GameOverManager.instance.onPlayerDeath();
    }

    public void Respawn(){
        PlayerMovement.instance.enabled = true;
        PlayerMovement.instance.animator.SetTrigger("Respawn");
        PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Dynamic;
        PlayerMovement.instance.playerCollider.enabled = true;
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
    }
    public IEnumerator InvincibilityFlash(){
        while(isInvincible){
            spriteRenderer.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(0.15f);
            spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(0.15f);
        }
        spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
    }

    public IEnumerator HandleInvisibilityDelay(){
        yield return new WaitForSeconds(2f);
        isInvincible = false;
    }
}
