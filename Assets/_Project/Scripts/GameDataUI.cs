using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameDataUI : MonoBehaviour {
	public Text gameCalendar;
	public Text gameCycleSegment;

	public Text deleteThis;
	public Company currentCompany;

	public GameController gameController;

	void Start () {
		gameController = GameObject.FindObjectOfType<GameController> ();
		var companies = gameController.gameDataBlueprint.companyList.Where ((o) => o.isBeingUsed == true);
		currentCompany = companies.ElementAt (0);
		gameCalendar.text = gameController.gameDataBlueprint.gameDateTime.PrettyDate ();
		gameCycleSegment.text = gameController.gameDataBlueprint.currentGameSegment.ToString ();
	}

	void Update () {
		gameCalendar.text = gameController.gameDataBlueprint.gameDateTime.PrettyDate ();
		gameCycleSegment.text = gameController.gameDataBlueprint.currentGameSegment.ToString ();
		deleteThis.text = currentCompany.companyName.ToString () + " $" + currentCompany.stockPrice;
	}

	public void ProcessNextTurn () {
		gameController.StartNextTurn ();
	}
}