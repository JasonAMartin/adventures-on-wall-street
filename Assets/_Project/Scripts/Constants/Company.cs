using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Company", menuName = "AdventuresOnWallStreet/Company", order = 10)]
public class Company : ScriptableObject {
    public string companyName;
    public string stockSymbol;
    public CompanyType companyType;
    public int stockPrice;
    public int earliestStartingDay;
    public CompanyLevel companyStrength;
    public string companyDescription;
    public bool canBeUsed = true;
    public bool wentBankrupt = false;
    public bool isBeingUsed = false;
    public CEO ceo;
    public StockPriceLevel stockPriceLevel;

    public void UpdateStockPrice () {
        stockPrice = stockPrice + 10;
    }
}