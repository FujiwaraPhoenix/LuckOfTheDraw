using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdiblePlant : MonoBehaviour {
    //Basic values: all plants have these.
    public int healthHealed, hungerRecovered;
    public SpriteRenderer spr;

    public enum possibleEffects
    {
        None,
        Poisoned,
        Paralyzed,
        Speedy,
        Slowed,
        Confused,
        Drunk,
        Hungry
    }

    public possibleEffects pE;
}
