using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public static GameController controller;
    List<string> actionLog = new List<string> (); // this is for log of what's happened. Break it out to component?
    // private static bool created = false;
    public static GameController instance;
    public GameDataBlueprint gameDataBlueprint = new GameDataBlueprint ();
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

    private void Awake () { }

    // Use this for initialization
    void Start () {
        currentGameState = GameStates.PENDING;
        // CEOS = Resources.Load<CEO>("ScriptableObjects/CEOs");
        canvasMainMenu = GameObject.Find ("MainMenuCanvas");
        canvasGame = GameObject.Find ("GameCanvas");
        canvasGameSetup = GameObject.Find ("GameSetupCanvas");
        canvasSaveGame = GameObject.Find ("SaveGameCanvas");
        canvasLoadGame = GameObject.Find ("LoadGameCanvas");
        canvasNewGame = GameObject.Find ("NewGameCanvas");
        canvasSettings = GameObject.Find ("SettingsCanvas");
        HideAllCanvas (canvasMainMenu);
    }

    public void HideAllCanvas (GameObject excludeCanvas) {
        canvasMainMenu.SetActive (false);
        canvasGame.SetActive (false);
        canvasGameSetup.SetActive (false);
        canvasSaveGame.SetActive (false);
        canvasLoadGame.SetActive (false);
        canvasNewGame.SetActive (false);
        canvasSettings.SetActive (false);
        if (excludeCanvas) excludeCanvas.SetActive (true);
    }

    // Update is called once per frame (FixedUpdate called on a regular timeline and called every physics step. )
    void Update () { }

    public void AddToHistoryLog (string history) {
        actionLog.Add (history);
    }

    public void ChangeScenes (string scene) {
        // keep _GameManagerScene + scene going. Dump others.
        // TODO: maybe this is bad. What if I wanted many scenes going. Perhaps a scene should just manage itself and unload when needed? How?
    }

    public GameDataBlueprint GetGameDataBlueprint () {
        return gameDataBlueprint;
    }

    public void SetGameDataBluePrint (GameDataBlueprint gameData) {
        gameDataBlueprint = gameData;
    }

    public void SetupNewGame (string playerName) {
        // TODO need to go back through all of this and account for game hardness!!!!!

        // TODO go through and make sure gameDataBlueprint has just data from assets bundle except for player initiated data.

        // TODO should check if Asset bundle is loaded, since it can only be loaded twice.

        var myLoadedAssetBundle = AssetBundle.LoadFromFile (Path.Combine (Application.dataPath, "aowsso"));
        if (myLoadedAssetBundle == null) {
            Debug.Log ("Failed to load AssetBundle!");
            return;
        }

        List<CompanyType> companyTypeList = myLoadedAssetBundle.LoadAsset<CompanyTypeList> ("companytypelist").companyTypelist;
        List<CompanyLevel> companyLevelList = myLoadedAssetBundle.LoadAsset<CompanyLevelList> ("companylevellist").companyLevelList;
        List<CEO> ceoList = myLoadedAssetBundle.LoadAsset<CEOList> ("ceolist").ceoList;
        List<GameDifficulty> gameDifficultyList = myLoadedAssetBundle.LoadAsset<GameDifficultyList> ("gamedifficultylist").gameDifficultyList;
        List<RuleSets> rulesetsList = myLoadedAssetBundle.LoadAsset<RuleSetsList> ("rulesetslist").ruleSetsList;
        gameDataBlueprint.gameDateTime = myLoadedAssetBundle.LoadAsset<GameDateTime> ("gamedatetime");

        // If game difficulty isn't set, make it NORMAL
        CheckGameSettings (gameDifficultyList);

        // get game difficulty setting
        // TODO this is repeated below in a method. Just pass this.
        var ruleDifficulty = rulesetsList.Where (o => o.difficulty.gameDifficultyName == gameDataBlueprint.gameDifficulty.gameDifficultyName); // easy, normal, hard

        // Set day to 0 and segment to DAY
        gameDataBlueprint.currentGameSegment = GameDataBlueprint.GameSegments.DAY;
        gameDataBlueprint.daysPlayed = 0;

        // Set play obj, player name, capital
        gameDataBlueprint.player = player;
        gameDataBlueprint.player.playerName = playerName;
        gameDataBlueprint.player.playerCapital = ruleDifficulty.ElementAt (0).playerStartingCapital;

        // set company list, ceo list
        gameDataBlueprint.companyList = myLoadedAssetBundle.LoadAsset<CompanyList> ("companylist").companyList;
        gameDataBlueprint.ceoList = ceoList;

        currentGameState = GameStates.GAME_READY;
        HideAllCanvas (canvasGame);
        if (companyLevelList.Count () < 1) {
            Debug.Log ("ERROR!!!!");
            return;
        }
        PickStartingCompanies (companyTypeList, companyLevelList, rulesetsList);
    }

    public void PickStartingCompanies (List<CompanyType> companyTypeList, List<CompanyLevel> companyLevelList, List<RuleSets> rulesetsList) {
        List<StockPriceLevel> stockPriceAllocation = SetupStockPriceLevelList ();
        List<CompanyLevel> companyLevelAllocation = SetupCompanyLevelList (rulesetsList, companyLevelList);
        System.Random rnd = new System.Random ();

        // I need 20 starting companies.
        // 1. go through each company type and pick 1 random company
        foreach (CompanyType currentType in companyTypeList) {
            // TODO: lots of repeated references. Clean up!!

            // all companies with this company type that can be started on first day
            var matchingCompanies = gameDataBlueprint.companyList.Where (o => o.companyType == currentType && o.earliestStartingDay < 2);
            // random #
            int diceRoll = rnd.Next (0, matchingCompanies.Count () - 1);

            // select company. Mark IsBeingUsed as true for starters
            matchingCompanies.ElementAt (diceRoll).isBeingUsed = true;

            // set random stock level
            int stockLevelDice = rnd.Next (0, stockPriceAllocation.Count ());
            StockPriceLevel currentStockPriceLevel = stockPriceAllocation.ElementAt (stockLevelDice);
            matchingCompanies.ElementAt (diceRoll).stockPriceLevel = currentStockPriceLevel;
            // remove element used
            stockPriceAllocation.RemoveAt (stockLevelDice);

            // set stock price
            int stockPriceDice = rnd.Next (matchingCompanies.ElementAt (diceRoll).stockPriceLevel.minimumStartingPrice, matchingCompanies.ElementAt (diceRoll).stockPriceLevel.maximimStartingPrice);
            matchingCompanies.ElementAt (diceRoll).stockPrice = stockPriceDice;

            // set company strength
            int companyStrengthDice = rnd.Next (0, companyLevelAllocation.Count () - 1);
            matchingCompanies.ElementAt (diceRoll).companyStrength = companyLevelAllocation.ElementAt (companyStrengthDice);
            companyLevelAllocation.RemoveAt (companyStrengthDice);

            // set ceo
            var matchingCeos = gameDataBlueprint.ceoList.Where (o => o.isEmployed == false);
            int ceoDice = rnd.Next (0, matchingCeos.Count () - 1);
            matchingCompanies.ElementAt (diceRoll).ceo = matchingCeos.ElementAt (ceoDice);

            // update CEO employment
            matchingCeos.ElementAt (ceoDice).isEmployed = true;
            matchingCeos.ElementAt (ceoDice).employedBy = matchingCompanies.ElementAt (diceRoll);
            matchingCeos.ElementAt (ceoDice).employmentHistory.Add (matchingCompanies.ElementAt (diceRoll));

        }

        DebugIt ();
    }

    public List<StockPriceLevel> SetupStockPriceLevelList () {
        // TODO -- remove hardcode
        int totalCompanies = 20;
        List<StockPriceLevel> spList = new List<StockPriceLevel> ();

        // iterate through all stock prices and put X copies in spList
        foreach (StockPriceLevel spl in stockPriceLevelList.stockPriceLevel) {
            float copies = totalCompanies * spl.startingThreshold;
            for (int i = 0; i < copies; i++) {
                spList.Add (spl);
            }
        }
        return spList;
    }

    public void CheckGameSettings (List<GameDifficulty> gameDifficultyList) {
        if (gameDataBlueprint.gameDifficulty == null) {
            // set game difficulty to default
            var defaultGameDifficulty = gameDifficultyList.Where (o => o.isDefault == true);
            gameDataBlueprint.gameDifficulty = defaultGameDifficulty.ElementAt (0);
        }
    }

    public List<CompanyLevel> SetupCompanyLevelList (List<RuleSets> rulesetsList, List<CompanyLevel> companyLevelList) {
        int totalLevels = 20;
        // get difficulty
        var ruleDifficulty = rulesetsList.Where (o => o.difficulty.gameDifficultyName == gameDataBlueprint.gameDifficulty.gameDifficultyName); // easy, normal, hard
        List<CompanyLevel> companyLevels = new List<CompanyLevel> ();

        // TODO this is hardcoded. Can I get away from this?
        var terribleProb = companyLevelList.Where (o => o.name == "CompanyLevelTerrible");
        var mediocreProb = companyLevelList.Where (o => o.name == "CompanyLevelMediocre");
        var greatProb = companyLevelList.Where (o => o.name == "CompanyLevelGreat");
        var goodProb = companyLevelList.Where (o => o.name == "CompanyLevelGood");
        var averageProb = companyLevelList.Where (o => o.name == "CompanyLevelAverage");

        float copiesTerrible = totalLevels * ruleDifficulty.ElementAt (0).terribleProbability;
        float copiesMediocre = totalLevels * ruleDifficulty.ElementAt (0).mediocreProbability;
        float copiesGreat = totalLevels * ruleDifficulty.ElementAt (0).greatProbability;
        float copiesGood = totalLevels * ruleDifficulty.ElementAt (0).goodProbability;
        float copiesAverage = totalLevels * ruleDifficulty.ElementAt (0).averageProbability;

        for (int i = 0; i < copiesTerrible; i++) { companyLevels.Add (terribleProb.ElementAt (0)); }
        for (int i = 0; i < copiesMediocre; i++) { companyLevels.Add (mediocreProb.ElementAt (0)); }
        for (int i = 0; i < copiesGreat; i++) { companyLevels.Add (greatProb.ElementAt (0)); }
        for (int i = 0; i < copiesGood; i++) { companyLevels.Add (goodProb.ElementAt (0)); }
        for (int i = 0; i < copiesAverage; i++) { companyLevels.Add (averageProb.ElementAt (0)); }

        return companyLevels;
    }

    public void StartDayCycle () {
        //??
        // Update stock prices
        ProcessStockPriceChanges ();
        // Update CEO stats
        // Update company stats
        // Any bankqrupties?
        // Any new companies?
        // process events that resolve this turn, this segment
        // preset new events
    }

    public void StartNightCycle () {
        // process events that resolve this turn, this segment
        // any new events?
        // event playing out scene
        // Night cycle is over, so inc days up by one.
    }

    public void StartNextTurn () {
        // Swap to next segment
        GameDataBlueprint.GameSegments nextSegment = (gameDataBlueprint.currentGameSegment == GameDataBlueprint.GameSegments.DAY) ? GameDataBlueprint.GameSegments.NIGHT : GameDataBlueprint.GameSegments.DAY;
        gameDataBlueprint.currentGameSegment = nextSegment;
        if (gameDataBlueprint.currentGameSegment == GameDataBlueprint.GameSegments.DAY) {
            gameDataBlueprint.daysPlayed++;
            gameDataBlueprint.GameDateTime.NextDay ();
            StartDayCycle ();
        }

        if (gameDataBlueprint.currentGameSegment == GameDataBlueprint.GameSegments.NIGHT) {
            StartNightCycle ();
        }
    }

    public void ProcessStockPriceChanges () {
        // For each company currently in use, process new stock price change
        var usedCompanies = gameDataBlueprint.companyList.Where (o => o.isBeingUsed == true);
        for (int index = 0; index < usedCompanies.Count (); index++) {
            usedCompanies.ElementAt (index).UpdateStockPrice ();
        }
    }

    public void DebugIt () {
        Debug.LogError ("CAP: " + gameDataBlueprint.player.playerCapital);
        var usedCompanies = gameDataBlueprint.companyList.Where (o => o.ceo != null);
        Debug.Log ("USED: " + usedCompanies.Count ());
        for (int index = 0; index < usedCompanies.Count (); index++) {
            Company currentCompany = usedCompanies.ElementAt (index);
            //  Debug.Log("company " + index + 1 + ": " + currentCompany.companyName + " price: " + currentCompany.stockPrice + " price level: " + currentCompany.stockPriceLevel + " str: " + currentCompany.companyStrength + " CEO: " + currentCompany.ceo);
            if (usedCompanies.ElementAt (index).ceo != null) {
                Debug.Log (index + " : " + usedCompanies.ElementAt (index).companyStrength);
            }
        }
    }
}