using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BayatGames.SaveGamePro;
using System.IO;

public class LoadGameButton : MonoBehaviour {
    public Button yourButton;
    public GameController gameController;
    public string gameSaveName;

    // Use this for initialization
    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(LoadGame);
    }

    // Update is called once per frame
    void LoadGame () {
        Debug.Log("game save is: " + gameSaveName);
        GameDataBlueprint temp = new GameDataBlueprint();
        gameController = GameObject.FindObjectOfType<GameController>();
        Debug.Log("name first: " + gameController.gameDataBlueprint.player.playerName);
        SaveGame.LoadInto<GameDataBlueprint>(gameSaveName, temp);
        gameController.SetGameDataBluePrint(temp);
        Debug.Log("You have clicked the button!");
        Debug.Log("name now: " + gameController.gameDataBlueprint.player.playerName);
        gameController.gameDataBlueprint.GameSaveFile = gameSaveName;
        gameController.currentGameState = GameController.GameStates.LOAD_GAME;
        Debug.Log("Testing game name: " + gameController.gameDataBlueprint.GameSaveFile);
    }
}
