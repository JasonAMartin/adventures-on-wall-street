using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "RuleSets", menuName = "AdventuresOnWallStreet/RuleSets", order = 4)]
public class RuleSets : ScriptableObject
{
    public GameDifficulty difficulty;
    public float terribleProbability; // terrible
    public float mediocreProbability; // mediocre
    public float averageProbability; // average
    public float goodProbability; // good
    public float greatProbability; // great
    public int playerStartingCapital;
}

