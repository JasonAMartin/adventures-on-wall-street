using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GeneralGameRules", menuName = "AdventuresOnWallStreet/GeneralGameRules", order = 4)]
public class GeneralGameRules : ScriptableObject
{
    public int tradingFeeMinimumCost = 75;
    public float tradingFee = .005f; // % of order.
    public int maximumCompaniesOnTradingFloor = 40;

    // success scoring
    public double pointsMakingMoneyOnStockSale = 1; // should be 5% or more or so to prevent easy cheating by buying/selling for 1 penny profit.
    public double pointsLosingMoneyOnStockSale = -1; // same
    public double pointsGettingScammed = -3;
    public double pointsStockSaleBonus25 = 1.5;
    public double pointsStockSaleBonus50 = 2;
    public double pointsStockSaleBonus100 = 3;
    public double pointsStockSaleLost25 = -1.5;
    public double pointsStockSaleLost50 = 2;
    public double pointsStockSaleLost100 = 3;
}
