using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager
{

	public void NavigateToMainMenu()
    {
        SceneManager.LoadScene("TitleScene", LoadSceneMode.Single);
    }
}
