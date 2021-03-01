using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float timeOffset;
    public Vector3 posOffset;
    private Vector3 velocity;
    public bool cameraFixX = false;
    public bool cameraFixY = false;
    public float fixX;
    public float fixY;

    void Update()
    {
        if(!cameraFixX && !cameraFixY){
            //transform.position -> emplacement de la caméra
            transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + posOffset, ref velocity, timeOffset);
        }
        else if(cameraFixX && cameraFixY){
            Vector3 vFix = new Vector3(fixX, fixY, player.transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, vFix + posOffset, ref velocity, timeOffset);
        }
        else if(cameraFixX){
            Vector3 vFixX = new Vector3(fixX, player.transform.position.y, player.transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, vFixX + posOffset, ref velocity, timeOffset);
        }
        else{
            Vector3 vFixY = new Vector3(player.transform.position.x, fixY, player.transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, vFixY + posOffset, ref velocity, timeOffset);
        }
    }
}
