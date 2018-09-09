using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Events", menuName = "AdventuresOnWallStreet/Events", order = 22)]
public class Events : ScriptableObject {
    public EventClassification eventClassification;
    public string eventName;
    public string eventHeadline;
    public string eventText;
    public EventType eventType;
    // TODO event rules list
    public EventRuleset eventRulesetList; // The criteria for the event 
    public bool isScam; // if true, this event always loses.
    public int daysUntilCompleted; // how many days must pass before outcome is revealed.
    public int capitalCashRequired; // Set this for setting hard $ amount for event.
    public float capitalPercentRequired; // Set this for setting hard PERCENT amount for event. Only set this or cash.
    public int resultCapitalCashGained; // the minimum amount the player gets
    public float resultCapitalPercentGained; // the percent of the player's money that is gained
}

/*
 * Need to work on money won/lost a bit.
 * 
 * 
 * // the formula for gain/loss is basically

(Player’s Capital * resultOutcomePercent) * EventRuleSetList[item.goodMultiplier,or bad]) 

OR resultMinimumCapitalAmount;
*/