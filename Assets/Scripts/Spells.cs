using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spells : MonoBehaviour
{
    public ParticleSystem salama;

    public static Spells instance;

    public enum Effects
    {
        summonthesaatana,
        salamia,
        pupu
    }

    private void Start()
    {
        instance = this;
    }

    public void Play(Effects effect)
    {
        switch (effect)
        {
            case Effects.summonthesaatana:
                break;
            case Effects.salamia:
                salama.Play();
                break;
            case Effects.pupu:
                break;
            default:
                break;
        }
    }

}
