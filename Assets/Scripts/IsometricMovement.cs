using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricMovement : MonoBehaviour
{
    public CharacterController controller;
    public Animator animator;

    public float speed = 6f;

    void Update()
    {
      float horizontal = Input.GetAxisRaw("Horizontal");
      float vertical = Input.GetAxisRaw("Vertical");
      Vector3 direction = new Vector3(horizontal, -0.4f, vertical).normalized;

      if (direction.magnitude >= 0.1f)
      {
        controller.Move(direction * speed * Time.deltaTime);

      }

      Vector3 HorizontalMovement = new Vector3(horizontal, 0, vertical).normalized;

      animator.SetFloat("Horizontal", horizontal);
      animator.SetFloat("Vertical", vertical);
      animator.SetFloat("Speed", HorizontalMovement.sqrMagnitude);
    }
}
