using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{

    
    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;
    float curSpeed;

    float horizontalMove = 0f;

    bool isJumping = false;
    bool isCrouching = false;

    // Start is called before the first frame update
    void Start()
    {
        curSpeed = runSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
        
        horizontalMove = Input.GetAxisRaw("Horizontal") * curSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));


        if (Input.GetButtonDown("Jump")) {
              isJumping = true;
              animator.SetBool("isJumping", true);
		}

        if (Input.GetButtonDown("Crouch")) {
            isCrouching = true;
            
		} else if (Input.GetButtonUp("Crouch")) {
            isCrouching = false;  
            
		}



    }

    void FixedUpdate () {
        controller.Move(horizontalMove * Time.fixedDeltaTime, isCrouching, isJumping);
        isJumping = false;
        
	}

    public void onLanding () {
        animator.SetBool("isJumping", false);
	}

    public void onCrouch (bool crouch) {
        animator.SetBool("isCrouching", crouch);
	}

    public void setSpeed(int numSlow) {
        curSpeed = (float)(runSpeed * Math.Pow(0.5, numSlow));
	}
}
