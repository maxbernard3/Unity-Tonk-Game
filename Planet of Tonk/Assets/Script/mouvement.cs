using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouvement : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    [SerializeField]
    private CharacterController controller;
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private float groudDistance = 0.5f;
    [SerializeField]
    private LayerMask groundMask;

    [SerializeField]
    private float speed = 12f;
    [SerializeField]
    private float turn = 5f;

    [SerializeField]
    private float gravity = -10f;

    Vector3 velocity;
    bool isOnGround;
    float Acceleration = 0.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isOnGround = Physics.CheckSphere(groundCheck.position, groudDistance, groundMask);

        if(isOnGround && velocity.y < 0f) 
        {
            velocity.y = -10f;
        }

        float x = Input.GetAxis("Horizontal") * turn * Time.deltaTime;
        float z = Input.GetAxis("Vertical");

        //movement
        Vector3 move = (transform.forward * z);

        controller.Move(move * Time.deltaTime);

        //gravity & acceleration
        velocity.y += gravity * Time.deltaTime; 
        controller.Move(velocity * Time.deltaTime);
        player.Rotate(Vector3.up * x);
    }
}
