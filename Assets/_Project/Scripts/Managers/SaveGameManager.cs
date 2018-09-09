using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveGameManager {

    public void SaveGameFile()
    {
        GameController gameController = GameObject.FindObjectOfType<GameController>();
        gameController.HideAllCanvas(gameController.canvasSaveGame);
    }

    public void UnloadSaveScene()
    {
        SceneManager.UnloadSceneAsync("SaveGameScene");
    }
}
