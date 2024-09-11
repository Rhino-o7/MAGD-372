using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Speed")]
    [SerializeField] float moveSpeed = 1;
    [SerializeField] float gravity = -9f;

    [Header("Ground Check")]
    [SerializeField] float groundDist = 0.4f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundMask;

    bool isGrounded;
    Vector3 velocity;
    CharacterController cc;


    void Awake(){
        cc = GetComponent<CharacterController>();
    }

    void Update(){
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDist, groundMask);
        if (isGrounded && velocity.y < 0){
            velocity.y = -2f;
        }

        Vector2 inputs;
        inputs.x = Input.GetAxis("Horizontal");
        inputs.y = Input.GetAxis("Vertical");

        Vector3 move = transform.right * inputs.x + transform.forward * inputs.y;
        cc.Move(move * moveSpeed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        cc.Move(velocity * Time.deltaTime);

        
    }

    
}
