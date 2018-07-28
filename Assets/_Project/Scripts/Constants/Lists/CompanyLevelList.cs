using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CompanyLevelList", menuName = "AdventuresOnWallStreet/CompanyLevelList", order = 19)]
public class CompanyLevelList : ScriptableObject
{
    public List<CompanyLevel> companyLevelList = new List<CompanyLevel>();
}
