using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Ball : MonoBehaviour
{
    public GameObject player;
    public Vector3 posOffSet;
    public Vector3 posOffSetFlipX;
    public GameObject ball;
    public Camera cam;
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public Collider2D col;
    [HideInInspector] public Vector3 pos{ get {return transform.position;} }
    private Text textTakeBall;
    private bool isRange;
    [HideInInspector] public bool isHoldBall = false;
    private bool isShooting = false;
    public Transform rangeCheck;
    public float rangeCheckRadius;
    public LayerMask collisionLayers;
    public Transform respawn;
    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        textTakeBall = GameObject.FindGameObjectWithTag("TakeBall").GetComponent<Text>();
    }
    void Start()
    {
        posOffSetFlipX.x = -posOffSet.x;
        posOffSetFlipX.y = posOffSet.y;
        posOffSetFlipX.z = posOffSet.z;
    }
    void Update()
    {
        if(isHoldBall && !isShooting){
            if(player.GetComponent<SpriteRenderer>().flipX){
                transform.position = player.transform.position + posOffSetFlipX;
            }
            else{ transform.position = player.transform.position + posOffSet;}
        }
        if(Input.GetKeyDown(KeyCode.E) && isRange && !isHoldBall){
            PickBall();
        }
        else if(Input.GetKeyDown(KeyCode.E) && isRange && isHoldBall){
            FallingBall();
        }
    }
    void FixedUpdate()
    {
        isRange = Physics2D.OverlapCircle(rangeCheck.position, rangeCheckRadius, collisionLayers);
        if(isRange){
            textTakeBall.enabled = true;
        }
        else{textTakeBall.enabled = false;}
    }

    public void push(Vector2 force){
        GetComponent<CircleCollider2D>().isTrigger = false;
        isShooting = true;
        isHoldBall = false;
        rb.AddForce(force, ForceMode2D.Impulse);
        textTakeBall.enabled = false;
    }
    public void ActivateRb(){
        rb.isKinematic = false;
    }
    public void DesactivateRb(){
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
        // angular velocity = vitesse rotation
        rb.angularVelocity = 0f;
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.CompareTag("SandBlock")){
            Destroy(gameObject);
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("DeathZone")){
            StaticBall();
            col.isTrigger = true;
            transform.position = respawn.position;
        }
    }
    public void PickBall(){
        transform.position = player.transform.position + posOffSet;
        isHoldBall = true;
        isShooting = false;
        StaticBall();
        col.isTrigger = true;
        textTakeBall.enabled = false;
    }
    public void FallingBall(){
        isHoldBall = false;
        ActivateRb();
        col.isTrigger = false;
    }
    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(rangeCheck.position, rangeCheckRadius);
    }
    public void StaticBall(){
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0f;
        rb.bodyType = RigidbodyType2D.Kinematic;
    }
    
}
