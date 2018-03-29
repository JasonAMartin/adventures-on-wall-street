using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveGameManager {

    public void SaveGameFile()
    {
        SceneManager.LoadScene("SaveGameScene", LoadSceneMode.Additive);
    }

    public void UnloadSaveScene()
    {
        SceneManager.UnloadSceneAsync("SaveGameScene");
    }
}
