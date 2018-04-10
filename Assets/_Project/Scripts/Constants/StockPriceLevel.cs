using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StockPriceLevel", menuName = "AdventuresOnWallStreet/StockPriceLevel", order = 55)]
public class StockPriceLevel : ScriptableObject {
    public int minimumStartingPrice;
    public int maximimStartingPrice;
    public float startingThreshold;
}

