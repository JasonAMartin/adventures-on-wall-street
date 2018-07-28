using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CompanyType", menuName = "AdventuresOnWallStreet/CompanyType", order = 13)]
public class CompanyType : ScriptableObject
{
    public string companyType;
    public int minimumRequired;
}
