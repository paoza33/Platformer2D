using UnityEngine;

public class OutScreenZoneY : MonoBehaviour
{
    public CameraFollow cam;
    public GameObject player;
    // mettre un rigid body a la camera si l'on veut comparer la camera et non le joueur
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            cam.cameraFixY = true;
            cam.fixY = player.transform.position.y;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")){
            cam.cameraFixY = false;
        }
    }
}
