using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spells : MonoBehaviour
{
    public ParticleSystem salama, ascend, koiraAscend, hyttyset;

    public List<ParticleSystem> summonParticles;

    public static Spells instance;

    public GameObject saatana, makkara, pupu, isoMakkara, kukka, pullo, tolkki, koira, isoPupu;

    public AudioClip magic, koiraSound, hyttynen;

    public enum Effects
    {
        saatana,
        salamia,
        pupu,
        makkaraSade,
        kukkaSade,
        pulloSade,
        tolkkiSade,
        isoMakkara,
        makkaraAscension,
        koiraSade,
        hyttyset,
        jattiPupu
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
                Instantiate(saatana);
                break;
            case Effects.salamia:
                salama.Play();
                break;
            case Effects.pupu:
                break;
            case Effects.makkaraSade:
                StartCoroutine(SpawnRandom(makkara, power));
                break;
            case Effects.kukkaSade:
                StartCoroutine(SpawnRandom(kukka, power));
                break;
            case Effects.pulloSade:
                StartCoroutine(SpawnRandom(pullo, power));
                break;
            case Effects.tolkkiSade:
                StartCoroutine(SpawnRandom(tolkki, power));
                break;
            case Effects.isoMakkara:
                GameObject g = Instantiate(isoMakkara, Vector3.up * 20, Quaternion.identity);
                foreach (Rigidbody rb in g.GetComponentsInChildren<Rigidbody>())
                {
                    rb.AddTorque(new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10)) * 50);
                }
                break;
            case Effects.makkaraAscension:
                ascend.Play();
                break;
            case Effects.koiraSade:
                koiraAscend.Play();
                StartCoroutine(SpawnRandom(koira, power));
                AudioManager.instance.Play(koiraSound, 0.8f);
                break;
            case Effects.hyttyset:
                hyttyset.Play();
                AudioManager.instance.Play(hyttynen, 0.8f);
                break;
            case Effects.jattiPupu:
                Instantiate(isoPupu, Vector3.up * 20, Quaternion.identity);
                break;
            default:
                break;
        }
    }

    public void RitualEffect(List<GameObject> objs, List<Effects> effects, float power)
    {
        foreach (ParticleSystem p in summonParticles)
        {
            p.Play();
        }

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
                GameObject g = Instantiate(obj, new Vector3(Random.Range(-20, 20), 20, Random.Range(-20, 20)), Quaternion.identity);
                if (g.GetComponent<Rigidbody>())
                {
                    g.GetComponent<Rigidbody>().AddTorque(new Vector3(Random.Range(-20, 20), Random.Range(-20, 20), Random.Range(-20, 20)) * 50);
                }
                next += Random.Range(0.5f, 1f) / power;
            }
            yield return null;
        }

        yield return null;
    }

}
