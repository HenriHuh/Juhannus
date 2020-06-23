using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public Type type;
    public enum Type
    {
        makkara,
        tolkki,
        kukka
    }
    [HideInInspector] public bool used = false;
}
