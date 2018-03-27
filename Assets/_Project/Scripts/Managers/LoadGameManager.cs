using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BayatGames.SaveGamePro;
using System.IO;

public class LoadGameManager
{

    public void LoadGameFile()
    {
        //SaveGameSettings settings = SaveGame.DefaultSettings;
        //settings.Formatter = new BayatGames.SaveGamePro.Serialization.Formatters.Json.JsonFormatter();
        //settings.Storage = new BayatGames.SaveGamePro.IO.SaveGameFileStorage();
        //SaveGame.DefaultSettings = settings;


        ///SaveGame.Save("demo.json", files, settings);

        Debug.Log("load done");

    }
}
