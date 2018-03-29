using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StateButtonManager : MonoBehaviour
{
    public Button buttonName;
    public enum ButtonType { SAVE, LOAD, NEW, SETTINGS, QUIT, MAINMENU, UNLOADSAVE }
    public ButtonType buttonType;
    public InputField saveGameName;

    void Start()
    {
        Button btn = buttonName.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if (buttonType == ButtonType.LOAD)
        {
            LoadGameManager loadGameManager = new LoadGameManager();
            loadGameManager.LoadGameFile();
        }

        if (buttonType == ButtonType.SAVE)
        {
            SaveGameManager saveGameManager = new SaveGameManager();
            saveGameManager.SaveGameFile();
        }

        if (buttonType == ButtonType.UNLOADSAVE)
        {
            SaveGameManager saveGameManager = new SaveGameManager();
            saveGameManager.UnloadSaveScene();
        }

        if (buttonType == ButtonType.NEW)
        {
            NewGameManager newGameManager = new NewGameManager();
            newGameManager.NewGameSetup();
        }

        if (buttonType == ButtonType.SETTINGS)
        {
            SettingsGameManager settingsGameManager = new SettingsGameManager();
            settingsGameManager.SettingsSetup();
        }

        if (buttonType == ButtonType.QUIT)
        {
            QuitGameManager quitGameManager = new QuitGameManager();
            quitGameManager.QuitGame();
        }


        if (buttonType == ButtonType.MAINMENU)
        {
            MainMenuManager mainMenuManager = new MainMenuManager();
            mainMenuManager.NavigateToMainMenu();
        }
        Debug.Log("You have clicked the button of type " + buttonType);
    }
}
