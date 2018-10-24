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
        SpeedIncrease,
        SpeedDecrease,
        HPRegenIncrease,
        HPRegenDecrease,
        DRIncrease,
        DRDecrease,
    }

    public possibleEffects pE;
}
