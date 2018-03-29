using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewGameSetPlayerName : MonoBehaviour {
    public InputField newPlayerName;
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
        // Save player name where???

        // switch to Game Setting Up Scene
        SceneManager.LoadScene("GameSettingUpScene", LoadSceneMode.Single);
    }
}
