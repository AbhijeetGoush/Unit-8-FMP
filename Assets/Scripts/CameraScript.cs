using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    [Range(1, 10)]
    public float smoothFactor;

    private void FixedUpdate()
    {
        Follow();
    }

    void Follow()
    {
        if (player != null)
        {
            Vector3 playerPosition = player.position + offset;
            Vector3 smoothPosition = Vector2.Lerp(transform.position, playerPosition, smoothFactor * Time.fixedDeltaTime);
            transform.position = playerPosition;
        }
        
    }

}
