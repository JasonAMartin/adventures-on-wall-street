using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitGameManager
{

    public void QuitGame()
    {
        //SaveGameSettings settings = SaveGame.DefaultSettings;
        //settings.Formatter = new BayatGames.SaveGamePro.Serialization.Formatters.Json.JsonFormatter();
        //settings.Storage = new BayatGames.SaveGamePro.IO.SaveGameFileStorage();
        //SaveGame.DefaultSettings = settings;


        ///SaveGame.Save("demo.json", files, settings);

        Debug.Log("you quit!");

    }
}