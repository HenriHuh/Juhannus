using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAsleep : MonoBehaviour
{
    Rigidbody rb;
    
    void Awake()
    {
      rb = GetComponent<Rigidbody>();
      rb.Sleep();
    }

}
