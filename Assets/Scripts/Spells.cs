﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spells : MonoBehaviour
{
    public ParticleSystem salama;

    public static Spells instance;

    public GameObject makkara, pupu, isoMakkara;

    public AudioClip magic;

    public enum Effects
    {
        saatana,
        salamia,
        pupu,
        makkaraSade,
        isoMakkara
    }

    private void Start()
    {
        instance = this;
    }

    public void Play(Effects effect, float power)
    {
        switch (effect)
        {
            case Effects.saatana:
                break;
            case Effects.salamia:
                salama.Play();
                break;
            case Effects.pupu:
                break;
            case Effects.makkaraSade:
                StartCoroutine(SpawnRandom(makkara, power));
                break;
            case Effects.isoMakkara:
                GameObject g = Instantiate(isoMakkara, Vector3.up * 20, Quaternion.identity);
                foreach (Rigidbody rb in g.GetComponentsInChildren<Rigidbody>())
                {
                    rb.AddTorque(new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10)) * 50);
                }
                break;
            default:
                break;
        }
    }

    public void RitualEffect(List<GameObject> objs, List<Effects> effects, float power)
    {
        AudioManager.instance.Play(magic, 0.7f);
        StartCoroutine(Ritual(objs, effects, power));
    }

    IEnumerator Ritual(List<GameObject> objs, List<Effects> effects, float power)
    {
        float t = 0;
        while (t < 2f)
        {
            foreach (GameObject g in objs)
            {
                Vector3 hoverDirection = Vector3.up * 5 - g.transform.position;
                g.GetComponent<Rigidbody>().AddTorque(hoverDirection * Time.deltaTime * 3.5f * t);
                g.GetComponent<Rigidbody>().AddForce(hoverDirection * Time.deltaTime * 300 * t);
                g.transform.position = Vector3.MoveTowards(g.transform.position, Vector3.up * 5, t * Time.deltaTime);
            }

            t += Time.deltaTime;
            yield return null;
        }

        foreach (GameObject g in objs)
        {
            Destroy(g);
        }

        foreach (Effects e in effects)
        {
            Play(e, power);
        }
        yield return null;
    }

    IEnumerator SpawnRandom(GameObject obj, float power)
    {
        float t = 0;
        float next = Random.Range(0.5f, 1f) / power;

        while (t < 2.5f)
        {
            t += Time.deltaTime;
            if (t > next)
            {
                GameObject g = Instantiate(obj, new Vector3(Random.Range(-10, 10), 20, Random.Range(-10, 10)), Quaternion.identity);
                if (g.GetComponent<Rigidbody>())
                {
                    g.GetComponent<Rigidbody>().AddTorque(new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10)) * 50);
                }
                next += Random.Range(0.5f, 1f) / power;
            }
            yield return null;
        }

        yield return null;
    }

}
