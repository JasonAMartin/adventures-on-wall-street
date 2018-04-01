using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CEOList", menuName = "AdventuresOnWallStreet/CEOList", order = 19)]
public class CEOList : ScriptableObject
{
    public List<CEO> ceoList = new List<CEO>();
}
