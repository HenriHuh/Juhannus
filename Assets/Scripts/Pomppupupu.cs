using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pomppupupu : MonoBehaviour
{
    public Transform groundCheck;
    public float groundDistance = 0.2f;
    public LayerMask groundMask;

    Rigidbody rb;
    bool isGrounded;
    float coolDownCounter;

    [SerializeField]
    float coolDownSpeed = 2f;
    [SerializeField]
    float jumpForce = 5f;


    void Start()
    {
      rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
      coolDownCounter = Mathf.MoveTowards(coolDownCounter, 1f, coolDownSpeed * Time.deltaTime);
      if (coolDownCounter == 1f)
      {
        GroundCheck();
        if (isGrounded)
        {
          coolDownCounter = 0f;
          Jump();
        }
      }
    }

    void GroundCheck()
    {
      isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }

    void Jump()
    {
      rb.velocity = new Vector3(Random.Range(-2.0f, 2.0f), jumpForce, Random.Range(-2.0f, 2.0f));
    }
}
