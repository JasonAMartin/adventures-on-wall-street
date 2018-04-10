using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StockPriceLevelList", menuName = "AdventuresOnWallStreet/StockPriceLevelList", order = 19)]
public class StockPriceLevelList : ScriptableObject
{
    public List<StockPriceLevel> stockPriceLevel = new List<StockPriceLevel>();
}
