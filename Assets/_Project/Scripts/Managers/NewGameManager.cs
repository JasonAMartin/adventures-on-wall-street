using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameManager
{

    public void NewGameSetup()
    {



        //SaveGameSettings settings = SaveGame.DefaultSettings;
        //settings.Formatter = new BayatGames.SaveGamePro.Serialization.Formatters.Json.JsonFormatter();
        //settings.Storage = new BayatGames.SaveGamePro.IO.SaveGameFileStorage();
        //SaveGame.DefaultSettings = settings;


        ///SaveGame.Save("demo.json", files, settings);
        


        if (!ifScene_CurrentlyLoaded_inEditor("NewGameSetupScene") && !isScene_CurrentlyLoaded("NewGameSetupScene"))
        {
            Debug.Log("1st load???? " + ifScene_CurrentlyLoaded_inEditor("NewGameSetupScene"));
            SceneManager.LoadScene("NewGameSetupScene", LoadSceneMode.Additive);
        } else
        {
            Debug.Log("Hi ---");
        }

        //       SceneManager.UnloadSceneAsync("TitleScene");
        Debug.Log("setup done");

    }

    public void UnloadScene()
    {
        SceneManager.UnloadSceneAsync("NewGameSetupScene");
    }


#if UNITY_EDITOR
    bool ifScene_CurrentlyLoaded_inEditor(string sceneName_no_extention)
    {
        for (int i = 0; i < UnityEditor.SceneManagement.EditorSceneManager.sceneCount; ++i)
        {
            var scene = UnityEditor.SceneManagement.EditorSceneManager.GetSceneAt(i);

            if (scene.name == sceneName_no_extention)
            {
                return true;//the scene is already loaded
            }
        }
        //scene not currently loaded in the hierarchy:
        return false;
    }
#endif


    bool isScene_CurrentlyLoaded(string sceneName_no_extention)
    {
        for (int i = 0; i < SceneManager.sceneCount; ++i)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            if (scene.name == sceneName_no_extention)
            {
                //the scene is already loaded
                return true;
            }
        }

        return false;//scene not currently loaded in the hierarchy
    }

}