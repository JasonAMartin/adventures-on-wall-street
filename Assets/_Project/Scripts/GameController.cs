using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using System.IO;

public class GameController : MonoBehaviour {

    public static GameController controller;
    List<string> actionLog = new List<string>(); // this is for log of what's happened. Break it out to component?
                                                 // private static bool created = false;
    public static GameController instance;
    public GameDataBlueprint gameDataBlueprint = new GameDataBlueprint();
    public enum GameStates { PENDING, LOAD_GAME, NEW_GAME, GAME_LOADED, SAVE_GAME, GAME_SAVED, GAME_READY };
    public GameStates currentGameState;

    // Scriptable Object Data
    public CEOList ceos;
    public CompanyList companies;
    public Player player;
    public GameObject canvasMainMenu;
    public GameObject canvasGame;
    public GameObject canvasGameSetup;
    public GameObject canvasSaveGame;
    public GameObject canvasLoadGame;
    public GameObject canvasNewGame;
    public GameObject canvasSettings;
    public StockPriceLevelList stockPriceLevelList;

    private void Awake() { }

    // Use this for initialization
    void Start() {
        currentGameState = GameStates.PENDING;
        // CEOS = Resources.Load<CEO>("ScriptableObjects/CEOs");
        canvasMainMenu = GameObject.Find("MainMenuCanvas");
        canvasGame = GameObject.Find("GameCanvas");
        canvasGameSetup = GameObject.Find("GameSetupCanvas");
        canvasSaveGame = GameObject.Find("SaveGameCanvas");
        canvasLoadGame = GameObject.Find("LoadGameCanvas");
        canvasNewGame = GameObject.Find("NewGameCanvas");
        canvasSettings = GameObject.Find("SettingsCanvas");
        HideAllCanvas(canvasMainMenu);
    }

    public void HideAllCanvas(GameObject excludeCanvas)
    {
        canvasMainMenu.SetActive(false);
        canvasGame.SetActive(false);
        canvasGameSetup.SetActive(false);
        canvasSaveGame.SetActive(false);
        canvasLoadGame.SetActive(false);
        canvasNewGame.SetActive(false);
        if (excludeCanvas) excludeCanvas.SetActive(true);
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

    public void SetupNewGame(string playerName)
    {
        // TODO need to go back through all of this and account for game hardness!!!!!

        // TODO go through and make sure gameDataBlueprint has just data from assets bundle except for player initiated data.

        var myLoadedAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.dataPath, "aowsso"));
        if (myLoadedAssetBundle == null)
        {
            Debug.Log("Failed to load AssetBundle!");
            return;
        }

        List<CompanyType> companyTypeList = myLoadedAssetBundle.LoadAsset<CompanyTypeList>("companytypelist").companyTypelist;
        List<CompanyLevel> companyLevelList = myLoadedAssetBundle.LoadAsset<CompanyLevelList>("companylevellist").companyLevelList;
        List<CEO> ceoList = myLoadedAssetBundle.LoadAsset<CEOList>("ceolist").ceoList;

        gameDataBlueprint.player = player;
        gameDataBlueprint.player.playerName = playerName;
        gameDataBlueprint.companyList = myLoadedAssetBundle.LoadAsset<CompanyList>("companylist").companyList;
        gameDataBlueprint.ceoList = ceoList;
        currentGameState = GameStates.GAME_READY;
        HideAllCanvas(canvasSaveGame);
        if (companyLevelList.Count() < 1)
        {
            Debug.Log("ERROR!!!!");
            return;
        }
        PickStartingCompanies(companyTypeList, companyLevelList);
    }

    public void PickStartingCompanies(List<CompanyType> companyTypeList, List<CompanyLevel> companyLevelList)
    {
        List<StockPriceLevel> stockPriceAllocation = SetupStockPriceLevelList();
        System.Random rnd = new System.Random();

        // I need 20 starting companies.
        // 1. go through each company type and pick 1 random company
        foreach (CompanyType currentType in companyTypeList)
        {
            // TODO: lots of repeated references. Clean up!!

            // all companies with this company type that can be started on first day
            var matchingCompanies = gameDataBlueprint.companyList.Where(o => o.companyType == currentType && o.earliestStartingDay < 2);
            // random #
            int diceRoll = rnd.Next(0, matchingCompanies.Count() - 1);

            // select company. Mark IsBeingUsed as true for starters
            matchingCompanies.ElementAt(diceRoll).isBeingUsed = true;

            // set random stock level
            int stockLevelDice = rnd.Next(0, stockPriceAllocation.Count());
            StockPriceLevel currentStockPriceLevel = stockPriceAllocation.ElementAt(stockLevelDice);
            matchingCompanies.ElementAt(diceRoll).stockPriceLevel = currentStockPriceLevel;
            // remove element used
            stockPriceAllocation.RemoveAt(stockLevelDice);

            // set stock price
            int stockPriceDice = rnd.Next(matchingCompanies.ElementAt(diceRoll).stockPriceLevel.minimumStartingPrice, matchingCompanies.ElementAt(diceRoll).stockPriceLevel.maximimStartingPrice);
            matchingCompanies.ElementAt(diceRoll).stockPrice = stockPriceDice;


            // set company strength
            int companyStrengthDice = rnd.Next(0, companyLevelList.Count() - 1);
            matchingCompanies.ElementAt(diceRoll).companyStrength = companyLevelList.ElementAt(companyStrengthDice);

            // set ceo
            var matchingCeos = gameDataBlueprint.ceoList.Where(o => o.isEmployed == false);
            int ceoDice = rnd.Next(0, matchingCeos.Count() - 1);
            matchingCompanies.ElementAt(diceRoll).ceo = matchingCeos.ElementAt(ceoDice);

            // update CEO employment
            matchingCeos.ElementAt(ceoDice).isEmployed = true;
            matchingCeos.ElementAt(ceoDice).employedBy = matchingCompanies.ElementAt(diceRoll);
            matchingCeos.ElementAt(ceoDice).employmentHistory.Add(matchingCompanies.ElementAt(diceRoll));

        }

        var usedCompanies = gameDataBlueprint.companyList.Where(o => o.ceo != null);

        Debug.Log("USED: " + usedCompanies.Count());
        for (int index = 0; index < usedCompanies.Count(); index++)
        {
            Company currentCompany = usedCompanies.ElementAt(index);
            //  Debug.Log("company " + index + 1 + ": " + currentCompany.companyName + " price: " + currentCompany.stockPrice + " price level: " + currentCompany.stockPriceLevel + " str: " + currentCompany.companyStrength + " CEO: " + currentCompany.ceo);
            if (usedCompanies.ElementAt(index).ceo != null)
            {
                Debug.Log(index + " : " + usedCompanies.ElementAt(index).ceo);
                Debug.Log("sub--" + index + " : "); //.firstName.ToString()           
            }
        }
   
    }

    public List<StockPriceLevel> SetupStockPriceLevelList()
    {
        // TODO -- remove hardcode
        int totalCompanies = 20;
        List<StockPriceLevel> spList = new List<StockPriceLevel>();

        // iterate through all stock prices and put X copies in spList
        foreach (StockPriceLevel spl in stockPriceLevelList.stockPriceLevel)
        {
            float copies = totalCompanies * spl.startingThreshold;
            for (int i = 0; i < copies; i++)
            {
                spList.Add(spl);
            }
        }
        return spList;
    }
}
