using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    private bool isRange;
    public Animator animator;
    private Text interactUI;
    public int coinsToAdd;
    public AudioClip audioclip;
    // Start is called before the first frame update
    void Awake()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && isRange){
            ChestOpening();
            interactUI.enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            isRange = true;
            interactUI.enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")){
            isRange = false;
            interactUI.enabled = false;
        }
    }

    private void ChestOpening(){
        animator.SetTrigger("ChestOpen");
        AudioManager.instance.PlayClipAt(audioclip, transform.position);
        Inventory.instance.AddCoins(coinsToAdd);
        GetComponent<BoxCollider2D>().enabled = false;
        isRange = false;
    }
}
