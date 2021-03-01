using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    private bool isInRange;
    Text test;

    private Text interactUI;
    // Update is called once per frame
    private void Awake() {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }
    void Update()
    {
        if(isInRange && Input.GetKeyDown(KeyCode.E)){
            PlayerMovement.instance.enabled = false;
            PlayerMovement.instance.rb.velocity = Vector3.zero;
            PlayerMovement.instance.animator.SetFloat("Speed", 0);
            interactUI.enabled = false;
            TriggerDialogue();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            isInRange = true;
            interactUI.enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")){
            isInRange = false;
            interactUI.enabled = false;
        }
    }
    void TriggerDialogue(){
        if(tag == "PNJ"){
            DialogueManager.instance.StartDialogue(dialogue,"PNJ");
        }
        else if(tag == "Marchand"){
            DialogueManager.instance.StartDialogue(dialogue,"Marchand");
        }
    }
}
