using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Company", menuName = "AdventuresOnWallStreet/Company", order = 10)]
public class Company : ScriptableObject
{
    public string companyName;
    public string stockSymbol;
    public CompanyType companyType;
    public int stockPrice;
    public int earliestStartingDay;
    public CompanyLevel companyStrength;
    public string companyDescription;
    public bool inBusiness = true;
    public CEO ceo;
}
