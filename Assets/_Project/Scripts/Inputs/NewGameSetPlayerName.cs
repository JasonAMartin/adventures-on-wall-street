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

        // switch to Game Setting Up Scene
        SceneManager.LoadScene("GameSettingUpScene", LoadSceneMode.Additive);
    }
}
