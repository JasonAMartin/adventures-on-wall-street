﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BayatGames.SaveGamePro;
using System.IO;

public class GameController : MonoBehaviour {

    public static GameController controller;
    public CEOLevel ceoLevel;
    public CEO CEOS;
    List<string> actionLog = new List<string>(); // this is for log of what's happened. Break it out to component?

   

    private void Awake()
    {
       // ceo.firstName = "LOL222Z";
      //  ceo.employmentTurns = 33;
        // Awake is called before Start and is called before script component is enabled
        /*
         * Saw this code here: https://unity3d.com/learn/tutorials/topics/scripting/persistence-saving-and-loading-data?playlist=17117
         * It's supposed to make it so there's only 1 persistant game controller so 
         * you don't need to do the bad game object find methods and such.
         */
        if (controller == null)
        {
            DontDestroyOnLoad(gameObject);
            controller = this;
        } else if (controller != this)
        {
            Destroy(gameObject);
        }

    }

    // Use this for initialization
    void Start () {
        //   ceoLevel.SetCEOData();
        //   print("CEO game controller: " + ceoLevel.compentcyScore);

        //      CEOS = Resources.Load<CEO>("ScriptableObjects/CEOs");

        SaveGameSettings settings = SaveGame.DefaultSettings;
        settings.Formatter = new BayatGames.SaveGamePro.Serialization.Formatters.Json.JsonFormatter();
        settings.Storage = new BayatGames.SaveGamePro.IO.SaveGameFileStorage();
        SaveGame.DefaultSettings = settings;


        FileInfo[] files = SaveGame.GetFiles();

        CEOLevel asset = ScriptableObject.CreateInstance<CEOLevel>();
          asset.compentcyScoreMaximum = 89;
          asset.compentcyScoreMinimum = 47;
          asset.employmentDaysMinimum = 1000;
          asset.employmentDaysMaximum = 9999;
        SaveGame.Save("demo.json", files, settings);

        Debug.Log("save done");

        Debug.Log("FILES: " + files[0]);

    }

    // Update is called once per frame (FixedUpdate called on a regular timeline and called every physics step. )
    void Update () {
    }

    public void AddToHistoryLog(string history)
    {
        actionLog.Add(history);
    }
}
