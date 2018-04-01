using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CompanyList", menuName = "AdventuresOnWallStreet/CompanyList", order = 19)]
public class CompanyList : ScriptableObject
{
    public List<Company> companyList = new List<Company>();
}
