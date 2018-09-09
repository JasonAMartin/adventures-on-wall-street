using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "CEOLevel", menuName = "AdventuresOnWallStreet/CEOLevel", order = 1)]
public class CEOLevel : ScriptableObject {
    // Employment days are what the CEO prefers and not what the company is likely to want, so a terrible CEO will try to stay longer since options are fewer.
    // TODO: need to create the % chance to go up or down a level on re-hire.
    // Ranges
    public float compentcyScoreMinimum;
    public float compentcyScoreMaximum;
    public int employmentDaysMinimum;
    public int employmentDaysMaximum;
    public GameLevels gameLevel;
}