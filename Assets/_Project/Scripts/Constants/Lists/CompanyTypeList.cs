using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CompanyTypeList", menuName = "AdventuresOnWallStreet/CompanyTypeList", order = 19)]
public class CompanyTypeList : ScriptableObject
{
    public List<CompanyType> companyTypelist = new List<CompanyType>();
}
