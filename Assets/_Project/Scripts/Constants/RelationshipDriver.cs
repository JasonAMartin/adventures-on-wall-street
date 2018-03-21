using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RelationshipDriver", menuName = "AdventuresOnWallStreet/RelationshipDriver", order = 27)]
public class RelationshipDriver : ScriptableObject {
    public PlayerActions playerAction;
    public GameActions gameAction;
    public CompanyType companyType;
    public GoodsType goodsType;
    public EventType eventType;
}
