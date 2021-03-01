using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public Item item;
    public AudioClip sound;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            Inventory.instance.AddItem(item.id);
            AudioManager.instance.PlayClipAt(sound, transform.position);
            Destroy(gameObject);
        }
    }
}
