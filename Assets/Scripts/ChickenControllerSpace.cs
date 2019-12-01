/*
 * Jeff McCluckerson - ChickenControllerCC.cs 
 * Player movement for Jeff using a Character Controller and simulates gravity
 * Movement for Jeff now is left and right
 * Includes function for updating difficulty (speed) and checking for death
 * TODO: Add jumping and sound effects
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenControllerSpace : MonoBehaviour
{
    private float movementSpeed;
    public float baseSpeed = 7.0f; // changes base speed of Jeff
    private float verticalVelocity;
    public float gravity;
    private float animationDuration;
    private float startTime; // fixes bug that causes camera movement after a restart
    private bool isDead;

    private Vector3 movement;

    private CharacterController controller;
    private Animator anim;

    public ParticleSystem LeftPropel, RightPropel;

    public CameraFollow cameraAudio;
    AudioSource bgMusic;

    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        animationDuration = 2.0f;
        verticalVelocity = 0.0f;
        movementSpeed = baseSpeed;
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        startTime = Time.time;

        bgMusic = cameraAudio.GetComponent<AudioSource>();
        StartCoroutine(AudioController.FadeIn(bgMusic, 3.5f)); // fade in background song
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            return;
        }

        // if our animation is playing
        if (Time.time - startTime < animationDuration)
        {
            // only move forward, not side to side
            controller.Move(Vector3.forward * movementSpeed * Time.deltaTime);
            return;
        }

        movement = Vector3.zero; // reset movement Vector after every frame
        verticalVelocity -= gravity * Time.deltaTime;

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.forward * movementSpeed * 20 * Time.deltaTime);
            RightPropel.Play();
        }
        else if (Input.GetKey(KeyCode.A))
            RightPropel.Play();
        else if (RightPropel.isPlaying)
            RightPropel.Stop();

        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(-Vector3.forward * movementSpeed * 20 * Time.deltaTime);
            LeftPropel.Play();
        }
        else if (Input.GetKey(KeyCode.D))
            LeftPropel.Play();
        else if (LeftPropel.isPlaying)
            LeftPropel.Stop();
        movement.x = Input.GetAxisRaw("Horizontal") * (movementSpeed / 2);// X - left and right movement
        movement.y = verticalVelocity; // Y - apply any gravity that has been calculated
        movement.z = movementSpeed; // Z - make Jeff move forward at a constant speed
        controller.Move(movement * Time.deltaTime); // move Jeff accordingly
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.10f);
    }

    // modifies speed based on difficulty level
    public void SetSpeed(float speedModifier)
    {
        // modify speed by the base amount of 5
        movementSpeed = baseSpeed + speedModifier;
        Debug.Log(movementSpeed);
    }

    // is called everytime Jeff collides with something
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Enemy")
            Death();
    }

    private void Death()
    {
        StartCoroutine(AudioController.FadeOut(bgMusic, 0.5f)); // fade out background song
        isDead = true;
        GetComponent<Score>().OnDeath();
    }
}
