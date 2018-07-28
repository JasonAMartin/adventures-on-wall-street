using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPC", menuName = "AdventuresOnWallStreet/NPC", order = 5)]
public class NPC : ScriptableObject {
    public string npcName;
    public Gender gender;
    public Occupation occupation;
    public Company company;
    public RelationshipType relationshipToPlayer;
    // public RelationshipDriversList 
    public List<Event> eventList;
    // public List<Dialog>
    public NPC friends;
    public NPC enemies;
    public bool hasMetPlayer = false;
    // public Mood mood;
    // public Personality personality
}
