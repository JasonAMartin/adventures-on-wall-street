using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using BayatGames.SaveGamePro;
using System.IO;

public class ButtonDemo : MonoBehaviour
{
    public Button yourButton;
    public GameController gameController;

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        GameDataBlueprint temp = new GameDataBlueprint();
        gameController = GameObject.FindObjectOfType<GameController>();
        Debug.Log("name first: " + gameController.gameDataBlueprint.player.playerName);
        SaveGame.LoadInto<GameDataBlueprint>("zzz", temp);
        gameController.SetGameDataBluePrint(temp);
        Debug.Log("You have clicked the button!");
        Debug.Log("name now: " + gameController.gameDataBlueprint.player.playerName);
    }
}