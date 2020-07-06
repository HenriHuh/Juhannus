using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpellListener : MonoBehaviour
{
    public static SpellListener instance;
    public UnityEvent saatana, salama, pupu, makkaraSade, kukkaSade, pulloSade, tolkkiSade, isoMakkara, makkaraAscension, koiraSade, hyttyset, isoPupu;

    public UnityEvent combSalami, combPullosade, combSekasotku;

    private void Start()
    {
        instance = this;
    }

    public void Invoke(string name)
    {
        if (name == "Salami")
        {
            combSalami.Invoke();
        }
        else if (name == "Pullosade")
        {
            combPullosade.Invoke();
        }
        else if (name == "Sekasotku")
        {
            combSekasotku.Invoke();
        }
    }

    public void Invoke(Spells.Effects effect)
    {
        switch (effect)
        {
            case Spells.Effects.saatana:
                saatana.Invoke();
                break;
            case Spells.Effects.salamia:
                salama.Invoke();
                break;
            case Spells.Effects.pupu:
                pupu.Invoke();
                break;
            case Spells.Effects.makkaraSade:
                makkaraSade.Invoke();
                break;
            case Spells.Effects.kukkaSade:
                kukkaSade.Invoke();
                break;
            case Spells.Effects.pulloSade:
                pulloSade.Invoke();
                break;
            case Spells.Effects.tolkkiSade:
                tolkkiSade.Invoke();
                break;
            case Spells.Effects.isoMakkara:
                isoMakkara.Invoke();
                break;
            case Spells.Effects.makkaraAscension:
                makkaraAscension.Invoke();
                break;
            case Spells.Effects.koiraSade:
                koiraSade.Invoke();
                break;
            case Spells.Effects.hyttyset:
                hyttyset.Invoke();
                break;
            case Spells.Effects.jattiPupu:
                isoPupu.Invoke();
                break;
            default:
                break;
        }
    }
}
