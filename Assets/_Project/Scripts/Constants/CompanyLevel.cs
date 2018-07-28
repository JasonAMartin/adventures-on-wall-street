using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "CompanyLevel", menuName = "AdventuresOnWallStreet/CompanyLevel", order = 9)]
public class CompanyLevel : ScriptableObject {
    // Ranges
    public float companyStrengthMin;
    public float companyStrengthMax;
    public GameLevels gameLevel;

    public int chanceToAffectCEOPositve;
    public int chanceToAffectCEONegative;
}