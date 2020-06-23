using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Combination", menuName = "Combinations/Combination", order = 1)]
public class Combination : ScriptableObject
{
    public List<Collectible.Type> types;
    public List<Spells.Effects> effects;
    [Tooltip("Increases amount of spawnable objects")]public float power = 1;
}
