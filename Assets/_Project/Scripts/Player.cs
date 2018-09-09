using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "AdventuresOnWallStreet/Player", order = 99)]
public class Player : ScriptableObject
{

    // Data
    public string playerName;
    public int playerCapital;
    public int playerScore;
    private int startingCapital = 50000;

}
