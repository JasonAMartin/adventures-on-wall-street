using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static GameController controller;
    List<string> actionLog = new List<string>(); // this is for log of what's happened. Break it out to component?
   // private static bool created = false;
    public string playerName;
    public static GameController instance;
    GameDataBlueprint gameDataBlueprint = new GameDataBlueprint();

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
        //if (controller == null)
        //{
        //    DontDestroyOnLoad(gameObject);
        //    controller = this;
        //} else if (controller != this)
        //{
        //    Destroy(gameObject);
        //}

        // BEST NOT TO USE IF POSSIBLE
        //if (!created)
        //{
        //    DontDestroyOnLoad(this.gameObject);
        //    created = true;
        //    Debug.Log("Awake ...");
        //}

    }

    // Use this for initialization
    void Start () {
        Debug.Log("STARTING GC");
    }

    // Update is called once per frame (FixedUpdate called on a regular timeline and called every physics step. )
    void Update () {
    }

    public void AddToHistoryLog(string history)
    {
        actionLog.Add(history);
    }

    public void SetPlayerName(string name)
    {
        gameDataBlueprint.playerName = name;
    }

    public void ChangeScenes(string scene)
    {
        // keep _GameManagerScene + scene going. Dump others.
        // TODO: maybe this is bad. What if I wanted many scenes going. Perhaps a scene should just manage itself and unload when needed? How?
    }

    public void SetCEOList(List<CEO> ceoList)
    {
        gameDataBlueprint.ceoList = ceoList;
    }

    public void SetPlayerCapital(int capital)
    {
        gameDataBlueprint.playerCapital = capital;
    }

    public GameDataBlueprint GetGameDataBlueprint()
    {
        return gameDataBlueprint;
    }

    public void SetGameDataBluePrint(GameDataBlueprint gameData)
    {
        gameDataBlueprint = gameData;
    }

    public string GetPlayername()
    {
        return gameDataBlueprint.playerName;
    }
}
