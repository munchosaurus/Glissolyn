using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
    private Transform thePlayer;
    private Vector3 desiredPos;

    private void Start()
    {
        thePlayer = GameObject.FindGameObjectWithTag("Character").transform;
    }

    void LateUpdate()
    {
        if(transform.position.x != thePlayer.position.x || transform.position.y != thePlayer.position.y)
        {
            desiredPos = thePlayer.position;
            desiredPos.z = transform.position.z;

            transform.position = desiredPos;
        }
    }
}
