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

public class ChickenControllerCC : MonoBehaviour
{
    private float movementSpeed;
    public float baseSpeed = 7.0f; // changes base speed of Jeff
    private float verticalVelocity;
    public float gravity;
    private float animationDuration;
    private float startTime; // fixes bug that causes camera movement after a restart
    private bool isDead;

    public float jumpSpeed;
    private bool isJumping = false;

    private Vector3 movement;

    private CharacterController controller;
    private Animator anim;

    public AudioSource bgMusic;
    public AudioSource bgEffect;
    AudioSource jump;

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

        jump = GetComponent<AudioSource>();
        StartCoroutine(AudioController.FadeIn(bgMusic, 3.5f)); // fade in background song
        StartCoroutine(AudioController.FadeIn(bgEffect, 3.5f)); // fade in background sound
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            anim.SetInteger("Walk", 0);
            return;
        }
        anim.SetInteger("Walk", 1); // animate Jeff to walk

        // if our animation is playing
        if (Time.time - startTime < animationDuration)
        {
            // only move forward, not side to side
            controller.Move(Vector3.forward * movementSpeed * Time.deltaTime);
            return;
        }

        movement = Vector3.zero; // reset movement Vector after every frame
        if (controller.isGrounded)
        {
            verticalVelocity -= gravity * Time.deltaTime;// makes sure Jeff is really on the ground
            if (Input.GetButton("Jump") && !isJumping)
            {
                isJumping = true;
                verticalVelocity = jumpSpeed;
                anim.SetTrigger("jump");
                jump.Play();
                Invoke("resetisJumping", 1.6f);
            }
        }
        else
            verticalVelocity -= gravity * Time.deltaTime;

        movement.x = Input.GetAxisRaw("Horizontal") * movementSpeed;// X - left and right movement
        movement.y = verticalVelocity; // Y - apply any gravity that has been calculated
        movement.z = movementSpeed; // Z - make Jeff move forward at a constant speed
        controller.Move(movement * Time.deltaTime); // move Jeff accordingly

        // adds rotation in direction of movement
        // if Jeff is on the ground, then cancel out the gravity before rotating
        // only if the game is not paused
        if(controller.isGrounded && !PauseMenu.isPaused)
        {
            movement.y = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
        }
        // else make the rotation downward after a jump less severe if the game is not paused
        else if(!PauseMenu.isPaused)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.05f);
    }

    // this function is called a certain amount of time after a jump is performed
    private void resetisJumping()
    {
        isJumping = false;
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
        StartCoroutine(AudioController.FadeOut(bgEffect, 0.5f)); // fade out background sound effect
        isDead = true;
        GetComponent<Score>().OnDeath();
    }
}
