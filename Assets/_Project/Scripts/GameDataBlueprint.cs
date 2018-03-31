using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDataBlueprint
{
    // Game Actors
    public CEOLevel ceoLevel;
    public List<CEO> ceoList;
    public List<Company> companyList;
    public List<NPC> npcList;

    // Game Data
    public GameDifficulty gameDifficulty;
    public int daysPlayed;

    // Player Data
    public string playerName;
    public int playerCapital;
    public int playerScore;
}
