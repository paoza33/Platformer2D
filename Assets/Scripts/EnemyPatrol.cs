using UnityEngine;
using System.Collections;

public class EnemyPatrol : MonoBehaviour
{
    public float speed;
    public Transform[] waypoints;
    private Transform target;

    //destpoint -> index de waypoints
    private int destPoint = 0;
    public SpriteRenderer spriteRenderer;
    public int damageOnCollision = 100;
    [HideInInspector] public bool isDead = false;
    public GameObject objectToDestroy;
    public Animator animator; 
    void Start()
    {
        target = waypoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(!isDead){
            //se déplace vers sa destination
            Vector3 dir = target.position - transform.position;
            // normalized met la magnitude du vecteur à 1
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
            //si l'ennemi arrive quasiment à sa destination
            if(Vector3.Distance(transform.position, target.position) < 0.3f){
                destPoint = (destPoint +1) % waypoints.Length;
                target= waypoints[destPoint];
                spriteRenderer.flipX = !spriteRenderer.flipX;
            }
        }
        else{
            Vector3 dir = Vector3.down;
            transform.Translate(dir.normalized * (speed/2) * Time.deltaTime, Space.World);
            animator.SetBool("Walk", false);
            animator.SetBool("Death", true);
            StartCoroutine(Death());
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.CompareTag("Player")){
            PlayerHealth playerHealth = other.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damageOnCollision);
        }
    }

    IEnumerator Death(){
        yield return new WaitForSeconds(0.5f);
        Destroy(objectToDestroy);
    }
}
