using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateButtonManager : MonoBehaviour
{
    public Button buttonName;
    public enum ButtonType { SAVE, LOAD, NEW, SETTINGS }
    public ButtonType buttonType;

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


        Debug.Log("You have clicked the button of type " + buttonType);
    }
}
