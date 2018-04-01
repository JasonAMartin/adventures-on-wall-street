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
    public Player player;

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

    public Player Player
    {
        get
        {
            return player;
        }

        set
        {
            player = value;
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

    // TODO make these get/sets below like ones above!! meh, wrong???
    /*
     *
     * Think this error is because I'm attaching Player to GameController. Since it's now a SO, it should be handled like others.
     * 
     * In the SaveGameType, it's reading name, capital and score like 3 things. This needs to be converted to 1 SO object and this should fix it.
     * 
     * case "playerName":
						gameDataBlueprint.SetPlayerName(reader.ReadProperty<System.String> ());
						break;
					case "playerCapital":
						gameDataBlueprint.SetPlayerCapital(reader.ReadProperty<System.Int32> ());
						break;
					case "playerScore":
						gameDataBlueprint.SetPlayerScore(reader.ReadProperty<System.Int32> ());
						break;
     */
}
