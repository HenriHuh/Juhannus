using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saatana : MonoBehaviour
{
    public Transform target;
    public AudioClip spawn;

    void Start()
    {
        AudioManager.instance.Play(spawn, 0.6f);
    }

    void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * 0.5f);
    }
}
