using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Events", menuName = "AdventuresOnWallStreet/Events", order = 22)]
public class Events : ScriptableObject {
    public EventClassification eventClassification;
    public string eventName;
    public string eventHeadline;
    public string eventText;
    // TODO event rules list
    public EventRuleset eventRulesetList; // The criteria for the event 
    public bool isGoodEvent; // true = good for player, false = bad for player
    public int daysUntilCompleted; // how many days must pass before outcome is revealed.
    public int capitalRequired; // how much money goes into holding for event
    public int resultMinimumCapitalAmount; // the minimum amount the player gets or loses
    public float resultOutcomePercent; // the percent of the player's money that is gained or lost.
}

/*
 * Need to work on money won/lost a bit.
 * 
 * 
 * // the formula for gain/loss is basically

(Player’s Capital * resultOutcomePercent) * EventRuleSetList[item.goodMultiplier,or bad]) 

OR resultMinimumCapitalAmount;
*/