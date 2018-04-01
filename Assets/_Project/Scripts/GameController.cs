using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static GameController controller;
    List<string> actionLog = new List<string>(); // this is for log of what's happened. Break it out to component?
                                                 // private static bool created = false;
    public static GameController instance;
    public GameDataBlueprint gameDataBlueprint = new GameDataBlueprint();
    public enum GameStates { PENDING, LOAD_GAME, NEW_GAME, GAME_LOADED, SAVE_GAME, GAME_SAVED };
    public GameStates currentGameState;

    // Scriptable Object Data
    public CEOList ceos;
    public CompanyList companies;
    public Player player;


    private void Awake() { }

    // Use this for initialization
    void Start() {
        currentGameState = GameStates.PENDING;
        // CEOS = Resources.Load<CEO>("ScriptableObjects/CEOs");
        SetupNewGame();
    }

    // Update is called once per frame (FixedUpdate called on a regular timeline and called every physics step. )
    void Update() {
    }

    public void AddToHistoryLog(string history)
    {
        actionLog.Add(history);
    }

    public void ChangeScenes(string scene)
    {
        // keep _GameManagerScene + scene going. Dump others.
        // TODO: maybe this is bad. What if I wanted many scenes going. Perhaps a scene should just manage itself and unload when needed? How?
    }

    public GameDataBlueprint GetGameDataBlueprint()
    {
        return gameDataBlueprint;
    }

    public void SetGameDataBluePrint(GameDataBlueprint gameData)
    {
        gameDataBlueprint = gameData;
    }

    public void SetupNewGame()
    {
        gameDataBlueprint.player = player;
        gameDataBlueprint.companyList = companies.companyList;
        gameDataBlueprint.ceoList = ceos.ceoList;
        Debug.Log("CEO List count: " + ceos.ceoList.Count);
        Debug.Log("Company List count: " + companies.companyList.Count);
    }
}
