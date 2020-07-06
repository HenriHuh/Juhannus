using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsoPomppupupu : MonoBehaviour
{
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public AudioClip megaPupuJump;

    Rigidbody rb;
    bool isGrounded;
    float coolDownCounter;
    float facing;

    [SerializeField]
    float coolDownSpeed = 2f;
    [SerializeField]
    float jumpForce = 10f;


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
      rb.velocity = new Vector3(Random.Range(-2.5f, 2.5f), jumpForce, Random.Range(-2.0f, 2.0f));
      Vector3 localScale = gameObject.transform.localScale;
      localScale.x *= -1;
      transform.localScale = localScale;
      AudioSource.PlayClipAtPoint(megaPupuJump, transform.position);
    }
}
