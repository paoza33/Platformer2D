using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float climbSpeed;
    private bool isJumping = false;
    private bool isGrounded = true;
    [HideInInspector]
    public bool isClimbing = false;
    public float jumpForce;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask collisionLayers;

    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;    // pour la ref dans SmoothDamp
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    private float horizontalMovement;
    private float verticalMovement;
    public CapsuleCollider2D playerCollider;

    public static PlayerMovement instance;
    private void Awake()
    {
        if(instance != null){
            Debug.LogWarning("il y a plus d'une instance de PlayerMovement");
            return;
        }
        instance = this;
    }

        // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.fixedDeltaTime;
        verticalMovement = Input.GetAxis("Vertical") * climbSpeed * Time.fixedDeltaTime;
        if(Input.GetButtonDown("Jump") && isGrounded && !isClimbing){
            isJumping = true;
        }
        Flip(rb.velocity.x);

        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", characterVelocity);
        animator.SetBool("isClimbing", isClimbing);
    }
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayers);
        MovePlayer(horizontalMovement, verticalMovement);
    }

    public void MovePlayer(float _horizontalMovement, float _verticalMovement){
        if(!isClimbing){
            //deplacement horizontal
            Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);  // déplace d'un endroit à un autre
            if(isJumping){
                rb.AddForce(new Vector2(0f, jumpForce));
                isJumping = false;
            }
        }else{
            //deplacement vertical
            Vector3 targetVelocity = new Vector2(0, _verticalMovement);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);  // déplace d'un endroit à un autre
        }
    }

    public void Flip(float _velocity){
        if(_velocity > 0.1f){
            spriteRenderer.flipX = false;
        }else if (_velocity < -0.1f){
            spriteRenderer.flipX = true;
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
