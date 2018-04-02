using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BayatGames.SaveGamePro;
using System.IO;

public class SaveGameName : MonoBehaviour {
    public InputField saveGameName;
    public SaveGameManager saveGameManager;
    public GameController gameController;

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

        gameController = GameObject.FindObjectOfType<GameController>();

       //  GameDataBlueprint saveGameFile = new GameDataBlueprint();

        
        SaveGameSettings settings = SaveGame.DefaultSettings;
        settings.Formatter = new BayatGames.SaveGamePro.Serialization.Formatters.Binary.BinaryFormatter();
        settings.Storage = new BayatGames.SaveGamePro.IO.SaveGameFileStorage();
        SaveGame.DefaultSettings = settings;


        FileInfo[] files = SaveGame.GetFiles();
        Debug.Log("FILES: " + files.Length);
        SaveGame.Save(saveGameName.text.ToString(), gameController.GetGameDataBlueprint(), settings);

        Debug.Log("save done. FILE: " + saveGameName.text);


        files = SaveGame.GetFiles();
        Debug.Log("UPDATED FILES: " + files.Length);
    }
}
