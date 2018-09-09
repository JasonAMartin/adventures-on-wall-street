using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewGameSetPlayerName : MonoBehaviour {
    public InputField newPlayerName;
    public GameController gameController;
    // Use this for initialization
    void Start () {
        //  saveGameName.placeholder = "Enter your save game name here ...";
    }

    public string GetName () {
        return newPlayerName.text;
    }

    public void StartNewGame () {

        GameController gameController = GameObject.FindObjectOfType<GameController> ();
        gameController.HideAllCanvas (gameController.canvasGameSetup);
        gameController.currentGameState = GameController.GameStates.NEW_GAME;
        gameController.SetupNewGame (newPlayerName.text);

        /*
         * a way to canvas switch if needed later

        // Switch off mainmenucanvas and switch on gamesettingupcanvas
        GameObject canvasMainMenu = GameObject.Find("MainMenuCanvas");
        GameObject canvasGameSetup = GameObject.Find("GameSetupCanvas");

        SceneManager.UnloadSceneAsync("NewGameSetupScene");
        canvasMainMenu.SetActive(false);
        canvasGameSetup.SetActive(true);

        // SceneManager.LoadScene("GameSettingUpScene", LoadSceneMode.Additive);
        */

    }
}