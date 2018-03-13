using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CEOLevel", menuName = "AdventuresOnWallStreet/CEOLevel", order = 1)]
public class CEOLevel : ScriptableObject
{
    // Ranges
    public float compentcyScoreMinimum;
    public float compentcyScoreMaximum;
    public float employmentDaysMinimum;
    public float employmentDaysMaximum;
    public GameLevels gameLevel;
}
