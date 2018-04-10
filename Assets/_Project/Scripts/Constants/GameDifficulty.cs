using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "GameDifficulty", menuName = "AdventuresOnWallStreet/GameDifficulty", order = 2)]
public class GameDifficulty : ScriptableObject
{
    public string gameDifficultyName;
    public bool isDefault = false;
}

