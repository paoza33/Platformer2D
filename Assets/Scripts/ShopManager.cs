using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public Animator animator;
    public static ShopManager instance;
    private void Awake() {
        if(instance != null){
            Debug.LogWarning("il y a plus d'une instance de ShopManager");
            return;
        }
        instance = this;
    }
    public void StartShop(GameObject shop){
        animator.SetBool("shopClose", false);
        shop.SetActive(true);
    }
    public void EndShop(){
        animator.SetBool("shopClose", true);
        PlayerMovement.instance.enabled = true;
    }
}
