using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewGameSetPlayerName : MonoBehaviour {
    public InputField newPlayerName;
    public GameController gameController;
	// Use this for initialization
	void Start () {
      //  saveGameName.placeholder = "Enter your save game name here ...";	
	}

    public string GetName()
    {
        return newPlayerName.text;
    }

    public void StartNewGame()
    {
        // Save player name where??? newPlayerName.text
        gameController = GameObject.FindObjectOfType<GameController>();
        gameController.SetPlayerName(newPlayerName.text);


        Debug.Log("player: " + newPlayerName.text);

        // Switch off mainmenucanvas and switch on gamesettingupcanvas
        GameObject canvasMainMenu = GameObject.Find("MainMenuCanvas");
        GameObject canvasGameSetup = GameObject.Find("GameSetupCanvas");

        SceneManager.UnloadSceneAsync("NewGameSetupScene");
        canvasMainMenu.SetActive(false);
        canvasGameSetup.SetActive(true);
       
        // SceneManager.LoadScene("GameSettingUpScene", LoadSceneMode.Additive);
    }
}
