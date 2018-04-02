using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsGameManager
{

    public void SettingsSetup()
    {

        GameController gameController = GameObject.FindObjectOfType<GameController>();
        gameController.HideAllCanvas(gameController.canvasSettings);
        //SaveGameSettings settings = SaveGame.DefaultSettings;
        //settings.Formatter = new BayatGames.SaveGamePro.Serialization.Formatters.Json.JsonFormatter();
        //settings.Storage = new BayatGames.SaveGamePro.IO.SaveGameFileStorage();
        //SaveGame.DefaultSettings = settings;


        ///SaveGame.Save("demo.json", files, settings);

        Debug.Log("settings done");

    }
   
}