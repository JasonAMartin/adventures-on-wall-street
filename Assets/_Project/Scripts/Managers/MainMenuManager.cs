using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager
{

	public void NavigateToMainMenu()
    {
        GameController gameController = GameObject.FindObjectOfType<GameController>();
        gameController.HideAllCanvas(gameController.canvasMainMenu);
    }
}
