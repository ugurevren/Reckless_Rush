using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    private void Start()
    {
        transform.rotation = Quaternion.Euler(30f, 0, 0);
    }

    void FixedUpdate()
    {
        
        Follow();
    }

    void Follow()
    {
        Vector3 targetPosition = new Vector3(0,target.position.y+offset.y,target.position.z+offset.z)+Vector3.up;
        transform.position=targetPosition;
    }

}
