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

    void CheckCombinations() //Dont look at this code :)
    {
        List<Collectible> temp = collected;
        List<Collectible> toRemove = new List<Collectible>();
        foreach (Combination com in combinations)
        {
            List<GameObject> objs = new List<GameObject>();
            bool failed = false;
            foreach (Collectible.Type ct in com.types)
            {
                bool fail = true;
                foreach (Collectible col in temp)
                {
                    if (col.type == ct && !col.used)
                    {
                        toRemove.Add(col);
                        objs.Add(col.gameObject);
                        fail = false;
                        col.used = true;
                        break;
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
                foreach (Collectible c in toRemove)
                {
                    collected.Remove(c);
                }

                MainMenu.instance.AddUnlock(com);
                Spells.instance.RitualEffect(objs, com.effects, com.power);
            }

            foreach (Collectible c in collected)
            {
                c.used = false;
            }
        }
    }
}
