using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EventRuleset", menuName = "AdventuresOnWallStreet/EventRuleset", order = 19)]
public class EventRuleset : ScriptableObject {
    public GameDifficulty gameDifficulty;
    public float goodEventMultiplier;
    public float badEventMultiplier;
}
