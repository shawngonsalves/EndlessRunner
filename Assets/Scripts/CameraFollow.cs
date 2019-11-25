/*
 * Jeff McCluckerson - CameraFollow.cs 
 * Makes the camera perform an animation at start of level
 * Follows in a stationary position behind Jeff
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform lookAt;
    private Vector3 offset;
    private Vector3 movement;
    private Vector3 animOffset;

    private float transition;
    private float animationDuration; // how long intro animation lasts

    // Start is called before the first frame update
    void Start()
    {
        animOffset = new Vector3(0, 4, 4);
        transition = 0.0f;
        animationDuration = 2.0f;
        lookAt = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - lookAt.position;
    }

    // Update is called once per frame
    void Update()
    {
        movement = lookAt.position + offset;
        movement.x = 0; // X - make sure camera is always centered on track, not Jeff
        // Y - in case we add inclines or jumping to our game, this makes the camera follow Jeff on Y axis
        movement.y = Mathf.Clamp(movement.y, 3, 8);

        // if we have completed the animation, move normally
        if(transition > 1.0f)
        {
            transform.position = movement;
        }
        // else we are in animation and camera is moving to position
        else
        {
            // TODO: fix bug where camera briefly rotates on restart/start
            // move the camera towards the player starting from looking above
            transform.position = Vector3.Lerp(movement + animOffset, movement, transition);
            transform.LookAt(lookAt.position + Vector3.up);
            // increment transition time as animation progresses every frame.
            transition += Time.deltaTime * 1 / animationDuration;
        }
    }
}
