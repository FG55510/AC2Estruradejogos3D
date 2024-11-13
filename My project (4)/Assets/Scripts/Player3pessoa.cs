using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Player3pessoa : MonoBehaviour
{
    public Transform freelook;
    public float force;
    public float maxSpeed = 5f;
    public float smoothingFactor;

    Rigidbody rb;
    float hor;
    float ver;

    Vector3 direction;

    Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        

        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");
        float currentSpeed = Mathf.Lerp(animator.GetFloat("Speed"), rb.velocity.magnitude, Time.deltaTime * smoothingFactor);
        float currentDirection = Mathf.Lerp(animator.GetFloat("Direction"), direction.magnitude, Time.deltaTime * smoothingFactor);
        animator.SetFloat("Speed", currentSpeed);
        animator.SetFloat("Direction", currentDirection);

    }

    private void FixedUpdate()
    {
        Vector3 camFoward = transform.position - freelook.position;
        camFoward = new Vector3(camFoward.x, 0, camFoward.z).normalized;
        Vector3 camRight = Vector3.Cross(Vector3.up, camFoward).normalized;

        direction = camFoward * ver + camRight * hor;
        rb.AddForce(direction * force);

        // Limitar a velocidade do jogador
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
 
    }

     

}
