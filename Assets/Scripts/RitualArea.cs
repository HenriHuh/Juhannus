using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RitualArea : MonoBehaviour
{
    public List<Combination> combinations;

    List<Collectible> collected = new List<Collectible>();

    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.GetComponent<Collectible>())
        {
            collected.Add(col.gameObject.GetComponent<Collectible>());
            CheckCombinations();
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.GetComponent<Collectible>())
        {
            collected.Remove(col.gameObject.GetComponent<Collectible>());
        }
    }

    void CheckCombinations()
    {
        List<Collectible> toRemove = new List<Collectible>();
        foreach (Combination com in combinations)
        {
            bool failed = false;
            foreach (Collectible.Type ct in com.types)
            {
                bool fail = true;
                foreach (Collectible col in collected)
                {
                    if (col.type == ct)
                    {
                        toRemove.Add(col);
                        fail = false;
                    }
                }
                if (fail)
                {
                    failed = true;
                    break;
                }
            }
            if (!failed)
            {
                Debug.Log("BOOM");
                foreach (Collectible c in toRemove)
                {
                    collected.Remove(c);
                }

                foreach (Spells.Effects e in com.effects)
                {
                    Spells.instance.Play(e);
                }
            }
        }
    }
}
