using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameDifficultyList", menuName = "AdventuresOnWallStreet/GameDifficultyList", order = 19)]
public class GameDifficultyList : ScriptableObject
{
    public List<GameDifficulty> gameDifficultyList = new List<GameDifficulty>();
}

