using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EventClassification", menuName = "AdventuresOnWallStreet/EventClassification", order = 20)]
public class EventClassification : ScriptableObject {
    public ClassificationType classification;
    public float chanceToHappen;
}
