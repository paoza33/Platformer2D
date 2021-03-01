using UnityEngine;

public class LaunchBall : MonoBehaviour
{
    public Ball ball;
    Camera cam;
    [SerializeField] float pushForce = 50f;
    Vector2 startPoint;
    Vector2 endPoint;
    Vector2 direction;
    Vector2 force;
    float distance;
    bool isDragging = false;
    public Trajectory trajectory;
    public static LaunchBall instance;
    private void Awake() {
        if(instance != null){
            Debug.Log("il y a plus d'une instance de LaunchBall");
            return;
        }
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        ball.DesactivateRb();
    }

    // Update is called once per frame
    void Update()
    {
        if(ball.isHoldBall){
            if(Input.GetMouseButtonDown(0)){
                isDragging = true;
                OnDragStart();
            }
            if(Input.GetMouseButtonUp(0)){
                isDragging = false;
                OnDragEnd();
            }
            if(isDragging){
                OnDrag();
            }
        }
    }
    void OnDragStart(){
        ball.DesactivateRb();
        startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        // préciser l'axe Z quand la camera est en perspective, dans mon cas : Camera.main.nearClipPlane
        //startPoint = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        trajectory.Show();
    }
    void OnDrag(){
        endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        //endPoint = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        distance = Vector2.Distance(startPoint, endPoint);
        direction = (startPoint - endPoint).normalized;
        force = direction * distance * pushForce;
        if(force.x > 20f){ force.x = 20f;}
        if(force.y > 20f){ force.y = 20f;}
        trajectory.UpdateDots(ball.pos, force);
    }
    void OnDragEnd(){
        ball.ActivateRb();
        ball.push(force);
        trajectory.Hide();
    }
}
