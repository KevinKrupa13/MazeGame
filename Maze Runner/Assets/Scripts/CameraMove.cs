using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    public Transform player;
    public float smoothing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // LateUpdate is called last once per frame
    void LateUpdate()
    {
        if (transform.position != player.position) {
            Vector3 targetPosition = new Vector3(player.position.x, player.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
    }
}
