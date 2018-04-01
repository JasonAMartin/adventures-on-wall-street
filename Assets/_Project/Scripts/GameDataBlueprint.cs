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
    public string gameSaveFile;

    // Player Data
    public string playerName;
    public int playerCapital;
    public int playerScore;

    // Get/Set Methods

    public CEOLevel CEOLevel
    {
        get
        {
            return ceoLevel;
        }

        set
        {
            ceoLevel = value;
        }
    }

    public List<CEO> CEOList
    {
        get
        {
            return ceoList;
        }

        set
        {
            ceoList = value;
        }
    }

    public List<Company> CompanyList
    {
        get
        {
            return companyList;
        }

        set
        {
            companyList = value;
        }
    }

    public List<NPC> NPCList
    {
        get
        {
            return npcList;
        }

        set
        {
            npcList = value;
        }
    }

    public GameDifficulty GameDifficulty
    {
        get
        {
            return gameDifficulty;
        }

        set
        {
            gameDifficulty = value;
        }
    }

    public int DaysPlayed
    {
        get
        {
            return daysPlayed;
        }

        set
        {
            daysPlayed = value;
        }
    }

    public string GameSaveFile
    {
        get
        {
            return gameSaveFile;
        }

        set
        {
            gameSaveFile = value;
        }
    }

    public string PlayerName
    {
        get
        {
            return playerName;
        }

        set
        {
            playerName = value;
        }
    }

    public int PlayerCapital
    {
        get
        {
            return playerCapital;
        }

        set
        {
            playerCapital = value;
        }
    }

    public int PlayerScore
    {
        get
        {
            return playerScore;
        }

        set
        {
            playerScore = value;
        }
    }

}
