using UnityEngine;

public class WeakSpot : MonoBehaviour
{
    public AudioClip audioClip;
    public GameObject objectToDestroy;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            AudioManager.instance.PlayClipAt(audioClip,transform.position);
            objectToDestroy.GetComponent<EnemyPatrol>().isDead = true;
            objectToDestroy.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
