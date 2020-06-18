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

    public void RitualEffect(List<GameObject> objs, List<Effects> effects)
    {
        StartCoroutine(Ritual(objs, effects));
    }

    IEnumerator Ritual(List<GameObject> objs, List<Effects> effects)
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
            Play(e);
        }
        yield return null;
    }

}
