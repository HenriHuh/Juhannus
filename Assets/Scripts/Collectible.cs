using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public Type type;
    public List<AudioClip> collisionSound;
    public enum Type
    {
        makkara,
        tolkki,
        kukka
    }
    [HideInInspector] public bool used = false;
    

    private void OnCollisionEnter(Collision col)
    {
        if (collisionSound.Count > 0)
        {
            AudioManager.instance.Play(collisionSound[Random.Range(0, collisionSound.Count)], Random.Range(0.1f, 0.2f));

        }
    }

}
