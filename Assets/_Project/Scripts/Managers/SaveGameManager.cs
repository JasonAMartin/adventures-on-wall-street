using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BayatGames.SaveGamePro;
using System.IO;

public class SaveGameManager {

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
        SaveGame.Save("demo.json", files, settings);

        Debug.Log("save done");

        Debug.Log("FILES: " + files[0]);
    }
}
