using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RuleSetsList", menuName = "AdventuresOnWallStreet/RuleSetsList", order = 19)]
public class RuleSetsList : ScriptableObject
{
    public List<RuleSets> ruleSetsList = new List<RuleSets>();
}
