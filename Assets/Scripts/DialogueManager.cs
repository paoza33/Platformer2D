using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text sentencesText;
    public Text nextSentence;
    public Animator animator;
    private Queue<string> sentences;
    public static DialogueManager instance;
    public GameObject shopUI;
    private string _typeOfBot;
    private void Awake() {
        if(instance != null){
            Debug.LogWarning("il y a plus d'une instance de DialogueManager");
            return;
        }
        instance = this;
        sentences = new Queue<string>();
    }
    public void StartDialogue(Dialogue dialogue, string typeOfBot){
        _typeOfBot = typeOfBot;
        //Debug.Log("manager");
        animator.SetBool("isOpen", true);
        
        nameText.text = dialogue.name;
        
        sentences.Clear();
        
        foreach(string sentence in dialogue.sentences){
            sentences.Enqueue(sentence);
        }
        DisplayNextSentences();
    }
    public void DisplayNextSentences(){
        if(sentences.Count == 1 && _typeOfBot == "PNJ"){
            nextSentence.text = "CLOSE";
        }
        else if(sentences.Count == 1 && _typeOfBot == "Marchand"){
            //Debug.Log("display next");
            nextSentence.text = "SHOP";
        }
        else if(sentences.Count ==0){
            if(_typeOfBot == "PNJ"){
                //Debug.Log("count = 0");
                EndDialoguePNJ();
                return;
            }
            else if(_typeOfBot == "Marchand"){
                //bug non corrigé, on accède à cette endroit sans passer par l'appel de la fonction, incompréhensible
                EndDialogueMarchand();
                return;
            }
        }
        
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    IEnumerator TypeSentence(string sentence){
        
        sentencesText.text = "";

        foreach(char letter in sentence.ToCharArray()){
            sentencesText.text += letter;
            yield return new WaitForSeconds(0.01f);
        }
    }
    void EndDialoguePNJ(){
        animator.SetBool("isOpen", false);
        nextSentence.text = "CONTINUE ->";
        PlayerMovement.instance.enabled = true;
    }
    void EndDialogueMarchand(){
        animator.SetBool("isOpen", false);
        nextSentence.text = "CONTINUE ->";
        ShopManager.instance.StartShop(shopUI);
    }
}
