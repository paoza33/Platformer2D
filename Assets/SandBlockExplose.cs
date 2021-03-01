using UnityEngine;
using System.Collections;

public class SandBlockExplose : MonoBehaviour
{
    
    public Animator anim;
    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.CompareTag("CanonBall")){
            anim.SetBool("Explose",true);
            gameObject.GetComponent<Collider2D>().isTrigger = true;
            StartCoroutine(DestroySandBlock());
        }
    }
    IEnumerator DestroySandBlock(){
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
