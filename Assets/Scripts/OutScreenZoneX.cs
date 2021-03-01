using UnityEngine;

public class OutScreenZoneX : MonoBehaviour
{
    public CameraFollow cam;
    public GameObject player;
    // mettre un rigid body a la camera si l'on veut comparer la camera et non le joueur
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            cam.cameraFixX = true;
            cam.fixX = player.transform.position.x;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")){
            cam.cameraFixX = false;
        }
    }
}
