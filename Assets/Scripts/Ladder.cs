using UnityEngine;

public class Ladder : MonoBehaviour
{
    public bool ifInRange = false;
    public PlayerMovement playerMovement;
    public BoxCollider2D col;
    void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ifInRange && playerMovement.isClimbing && Input.GetKeyDown(KeyCode.UpArrow)){
            playerMovement.isClimbing = false;
            col.isTrigger = false;
            return;
        }
        if(ifInRange && Input.GetKeyDown(KeyCode.UpArrow)){
            playerMovement.isClimbing = true;
            col.isTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            ifInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")){
            playerMovement.isClimbing = false;
            ifInRange = false;
            col.isTrigger = false;
        }
    }
}
