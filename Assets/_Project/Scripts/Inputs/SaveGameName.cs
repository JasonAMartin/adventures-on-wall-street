using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BayatGames.SaveGamePro;
using System.IO;

public class SaveGameName : MonoBehaviour {
    public InputField saveGameName;
	// Use this for initialization
	void Start () {
      //  saveGameName.placeholder = "Enter your save game name here ...";	
	}

    public string GetName()
    {
        return saveGameName.text;
    }

    public void SaveGameFile()
    {
        SaveGameSettings settings = SaveGame.DefaultSettings;
        settings.Formatter = new BayatGames.SaveGamePro.Serialization.Formatters.Json.JsonFormatter();
        settings.Storage = new BayatGames.SaveGamePro.IO.SaveGameFileStorage();
        SaveGame.DefaultSettings = settings;


        FileInfo[] files = SaveGame.GetFiles();

        CEOLevel asset = ScriptableObject.CreateInstance<CEOLevel>();
        asset.compentcyScoreMaximum = 89;
        asset.compentcyScoreMinimum = 47;
        asset.employmentDaysMinimum = 1000;
        asset.employmentDaysMaximum = 9999;
        SaveGame.Save(saveGameName.text.ToString() + ".json", asset, settings);

        Debug.Log("save done. FILE: " + saveGameName.text);

        Debug.Log("FILES: " + files[0]);
    }
}
