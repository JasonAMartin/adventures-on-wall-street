using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EventRulesetList", menuName = "AdventuresOnWallStreet/EventRulesetList", order = 19)]
public class EventRulesetList : ScriptableObject
{
    public List<EventRuleset> eventRulesetList = new List<EventRuleset>();
}
